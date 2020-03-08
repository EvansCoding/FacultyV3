using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class Detail_MenuController : BaseController
    {
        private readonly IDetailMenuService detailMenuService;
        private readonly ICategoryMenuService categoryMenuService;

        public Detail_MenuController(IDetailMenuService detailMenuService, ICategoryMenuService categoryMenuService, IDataContext context) : base(context)
        {
            this.detailMenuService = detailMenuService;
            this.categoryMenuService = categoryMenuService;
        }

        public ActionResult Detail_MenuView()
        {
            List<Category_Menu> ListCategory = categoryMenuService.GetCategories();
            if (ListCategory != null)
                ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, string category, string state, int page = 1, int pageSize = 10)
        {
            var model = detailMenuService.PageList(search, category, state, page, pageSize);
            return PartialView("Detail_MenuTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            List<Category_Menu> ListCategory = categoryMenuService.GetCategories();

            try
            {
                var data = detailMenuService.GetPostByID(Id);
                if (data != null)
                {
                    var model = new DetailViewModel();
                    model.Title = data.Title;
                    model.Description = data.Description;
                    model.Content = data.Content;
                    model.Serial = data.Serial;
                    model.Status = data.Status ? Gender.PUBLISH.ToString() : Gender.UNPUBLISH.ToString();
                    model.Url_Image = data.Url_Image;
                    model.Url_Video = data.Url_Video;
                    model.Url_LinkGoogle = data.Url_LinkGoogle;

                    if (data.Category_Menu == null)
                        ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
                    else
                        ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name", data.Category_Menu.Id);
                    return PartialView("CRUDDetail_Menu", model);
                }
            }
            catch (Exception)
            {
            }
            ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
            return PartialView("CRUDDetail_Menu", new DetailViewModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(DetailViewModel model)
        {
            if (model.Id == null)
            {
                try
                {
                    Detail_Menu detail_Menu = new Detail_Menu()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Serial = model.Serial,
                        Status = model.Status.Equals(Gender.PUBLISH) ? true : false,
                        Url_Image = model.Url_Image == null ? "#" : model.Url_Image,
                        Url_Video = model.Url_Video == null ? "#" : model.Url_Video,
                        Url_LinkGoogle = model.Url_LinkGoogle == null ? "#" : model.Url_LinkGoogle,
                        Category_Menu = context.Category_Menus.Find(new Guid(model.CategoryID)),
                        Create_At = DateTime.Now,
                        Update_At = DateTime.Now,
                        Account = context.Accounts.Find(new Guid("32E6C2E0-5304-4330-B9D3-8978B4803E61"))
                    };

                    context.Detail_Menus.Add(detail_Menu);
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
                    var detail_Menu = detailMenuService.GetPostByID(model.Id);
                    detail_Menu.Title = model.Title;
                    detail_Menu.Description = model.Description;
                    detail_Menu.Content = model.Content;
                    detail_Menu.Serial = model.Serial;
                    detail_Menu.Status = model.Status.Equals(Gender.PUBLISH.ToString()) ? true : false;
                    detail_Menu.Url_Image = model.Url_Image == null ? "#" : model.Url_Image;
                    detail_Menu.Url_Video = model.Url_Video == null ? "#" : model.Url_Video;
                    detail_Menu.Url_LinkGoogle = model.Url_LinkGoogle == null ? "#" : model.Url_LinkGoogle;
                    detail_Menu.Update_At = DateTime.Now;
                    detail_Menu.Category_Menu = context.Category_Menus.Find(new Guid(model.CategoryID));
                    detail_Menu.Account = context.Accounts.Find(new Guid("32E6C2E0-5304-4330-B9D3-8978B4803E61"));

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
            return RedirectToAction("Detail_MenuView", "Detail_Menu");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var detail_Menu = context.Detail_Menus.Find(new Guid(Id));
                context.Detail_Menus.Remove(detail_Menu);
                context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Publish(string Id)
        {


            try
            {
                var post = detailMenuService.GetPostByID(Id);
                if (post.Status)
                {
                    post.Status = false;
                    context.SaveChanges();
                    return Json(new { success = true, message = "Ẩn bài viết thành công" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    post.Status = true;
                    context.SaveChanges();
                    return Json(new { success = true, message = "Công khai bài viết thành công" }, JsonRequestBehavior.AllowGet);
                }

              
            }
            catch (Exception)
            {

            }

            return Json(new { success = false, message = "Đã có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
        }
    }
}