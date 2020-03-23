using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System.Web.Mvc;
using System.Linq;
using FacultyV3.Core.Utilities;
using System;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IAccountService accountService;

        public ProfileController(IAccountService accountService, IDataContext context) : base(context)
        {
            this.accountService = accountService;
        }

        public ActionResult ProfileView()
        {

            try
            {
                var session = (UserLogin)Session[Constant.USER_SESSION];
                var data = accountService.GetAccountByID(session.UserID.ToString());
                var model = new LoginViewModel();
                model.Id = data.Id.ToString();
                model.FullName = data.FullName;
                model.Email = data.Email;
                model.Password = "";
                model.Create_At = data.Create_At;
                model.Update_At = data.Update_At;
                model.Role = data.Role.Name;
                return View("ProfileView", model);
            }
            catch (System.Exception)
            {
            }
            return RedirectToAction("Logon", "Login", new { Area = "Admin" });
        }


        [HttpPost]
        public ActionResult AddOrUpdate(LoginViewModel model)
        {

            var meta_name = context.Accounts.Where(x => x.Email.Contains(model.Email)).ToList();

            if (model.Id != null)
            {
                try
                {
                    var account = accountService.GetAccountByID(model.Id);

                    account.FullName = model.FullName;

                    if (model.Password != null)
                    {
                        var passwordHash = Hash.Instance.ComputeSha256Hash(model.Password);
                        if (!account.Password.Equals(passwordHash) && model.Password.Length >= 6)
                            account.Password = passwordHash;
                        else
                        {
                            TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                            {
                                Message = "Cập nhật mật khẩu không thành công",
                                MessageType = GenericMessages.error
                            };
                            return RedirectToAction("ProfileView", "Profile");
                        }
                    }

                    account.Update_At = DateTime.Now;

                    context.SaveChanges();

                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Cập nhật thành công!",
                        MessageType = GenericMessages.success
                    };
                }
                catch (Exception)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Cập nhật thất bại!",
                        MessageType = GenericMessages.error
                    };
                }

                return RedirectToAction("ProfileView", "Profile");
            }

            return RedirectToAction("Logon", "Login", new { Area = "Admin" });
        }
    }
}