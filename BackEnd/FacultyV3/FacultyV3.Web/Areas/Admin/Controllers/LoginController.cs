using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IDataContext context;
        private readonly IAccountService accountService;

        public LoginController(IAccountService accountService, IDataContext context)
        {
            this.context = context;
            this.accountService = accountService;
        }
       
        public ActionResult LoginView()
        {
            return View();
        }

        public ActionResult LogOn(LoginViewModel model)
        {
            var email = model.Email;
            var passwork = model.Password;
            if (ModelState.IsValid)
            {
                if (accountService.ValidateUser(email, passwork))
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    var user = accountService.GetEmail(email);
                    var userSession = new UserLogin();
                    userSession.Email = user.Email;
                    userSession.UserID = user.Id;
                    var creadential = user.Role.Name;
                    Session.Add(Constant.USER_SESSION, userSession);
                    Session.Add(Constant.SESSION_CREDENTIAL, creadential);
                    return RedirectToAction("ProfileView", "Profile", new { Area = "Admin" });
                }
            }
            return RedirectToAction("LoginView", "Login", new { Area = "Admin" });
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("LoginView", "Login", new { Area = "Admin" });
        }
    }
}