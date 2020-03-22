using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;

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
    }
}
