using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using FacultyV3.Core.Utilities;
using Microsoft.Security.Application;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FacultyV3.Core.Services
{
    public class AccountService : IAccountService
    {
        private IDataContext context;
        public AccountService(IDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Account> PageList(string name, int page, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return context.Accounts.Where(x => x.FullName.Contains(name)).OrderBy(x => x.FullName).ToPagedList(page, pageSize);
            }
            return context.Accounts.Include(x => x.Role).OrderBy(x => x.FullName).ToPagedList(page, pageSize);
        }

        public Account GetAccountByID(string id)
        {
            try
            {
                Guid ID = new Guid(id);
                return context.Accounts.Include(x => x.Role).Where(x => x.Id == ID).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
        public Account GetEmail(string email)
        {
            try
            {
                return context.Accounts.Include(x => x.Role).Where(x => x.Email.Equals(email)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
        public Account GetAccountByEmail(string email)
        {
            try
            {
                return context.Accounts.Include(x => x.Role).Where(x => x.Email.Contains(email)).SingleOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public List<Account> GetAccounts()
        {
            try
            {
                return context.Accounts.Include(x => x.Role).Select(x => x).OrderBy(x => x.Email).ToList();
            }
            catch (Exception)
            {
            }
            return null;
        }

        public LoginAttemptStatus LastLoginStatus { get; private set; } = LoginAttemptStatus.LoginSuccessful;
        public bool ValidateUser(string email, string password)
        {
            email = Sanitizer.GetSafeHtmlFragment(email);
            password = Sanitizer.GetSafeHtmlFragment(password);

            LastLoginStatus = LoginAttemptStatus.LoginSuccessful;

            var user = GetEmail(email);
            if (user == null)
            {
                LastLoginStatus = LoginAttemptStatus.UserNotFound;
                return false;
            }

            var passwordMatches = Hash.Instance.ComputeSha256Hash(password) == user.Password;
            if (!passwordMatches)
            {
                LastLoginStatus = LoginAttemptStatus.PasswordIncorrect;
                return false;
            }

            return LastLoginStatus == LoginAttemptStatus.LoginSuccessful;
        }
    }
}
