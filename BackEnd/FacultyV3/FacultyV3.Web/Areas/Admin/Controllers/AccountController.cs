using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Utilities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        public readonly IAccountService accountService;
        public readonly IRoleService roleService;

        public AccountController(IAccountService accountService, IRoleService roleService, IDataContext context) : base(context)
        {
            this.accountService = accountService;
            this.roleService = roleService;
        }
        // GET: Admin/Account
        public ActionResult AccountView()
        {
            return View();
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            List<Role> ListRole = context.Roles.ToList();
            //List<Category_Menu> ListParent = context.Category_Menus.Where(x => !x.Detail_Menus.Any() ).ToList();
            try
            {
                var data = accountService.GetAccountByID(Id);

                var model = new AccountViewModel();
                model.Id = data.Id.ToString();
                model.Email = data.Email;
                model.FullName = data.FullName;
                model.Password = "";
                if (data.Role == null)
                    ViewBag.ListOfRole = new SelectList(ListRole, "Id", "Name");
                else
                    ViewBag.ListOfRole = new SelectList(ListRole, "Id", "Name", data.Role.Id);
                return PartialView("CRUDAccount", model);
            }
            catch (Exception)
            {
            }
            ViewBag.ListOfRole = new SelectList(ListRole, "Id", "Name");
            return PartialView("CRUDAccount", new AccountViewModel());

        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = accountService.PageList(search, page, pageSize);
            return PartialView("AccountTablePartialView", model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(AccountViewModel model)
        {
            var role = roleService.GetRoleByID(model.RoleID);
            var meta_name = context.Accounts.Where(x => x.Email.Contains(model.Email)).ToList();

            if (model.Id == null)
            {
                if (meta_name.Count > 0)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Tên tài khoản  đã tồn tại!",
                        MessageType = GenericMessages.error
                    };

                    return RedirectToAction("AccountView", "Account");
                }

                try
                {
                    Account account = new Account()
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        Create_At = DateTime.Now,
                        Update_At = DateTime.Now,
                        Role = role
                    };
                    if (model.Password != null && model.Password.Length >= 6)
                    {
                        var passwordHash = Hash.Instance.ComputeSha256Hash(model.Password);
                            account.Password = passwordHash;
                    }
                    else
                    {
                        TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                        {
                            Message = "Mật khẩu chưa chính xác",
                            MessageType = GenericMessages.error
                        };

                        return RedirectToAction("AccountView", "Account");
                    }
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Thêm thành công",
                        MessageType = GenericMessages.success
                    };
                }
                catch (Exception)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Thêm thất bại",
                        MessageType = GenericMessages.error
                    };
                }
            }
            else
            {
                try
                {
                    var account = accountService.GetAccountByID(model.Id);

                    if (!account.Email.Equals(model.Email))
                    {
                        if (meta_name.Count > 0)
                        {
                            TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                            {
                                Message = "Tên tài khoản đã tồn tại!",
                                MessageType = GenericMessages.error
                            };

                            return RedirectToAction("AccountView", "Account");
                        }
                        else
                        {
                            account.Email = model.Email;
                        }
                    }

                    account.FullName = model.FullName;
                    if (model.Password != null )
                    {
                        var passwordHash = Hash.Instance.ComputeSha256Hash(model.Password);
                        if (!account.Password.Equals(passwordHash) && model.Password.Length >= 6)
                            account.Password = passwordHash;
                        else
                        {
                            TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                            {
                                Message = "Mật khẩu chưa chính xác",
                                MessageType = GenericMessages.error
                            };
                            return RedirectToAction("AccountView", "Account");
                        }
                    }


                  

                    account.Role = role;
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
            }
            return RedirectToAction("AccountView", "Account");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var account = context.Accounts.Find(new Guid(Id));
                context.Accounts.Remove(account);
                context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}