using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class Detail_NewsController : BaseController
    {
        private readonly IDetailNewsService detailNewsService;
        private readonly ICategoryNewsService categoryNewsService;

        public Detail_NewsController(IDetailNewsService detailNewsService, ICategoryNewsService categoryNewsService, IDataContext context) : base(context)
        {
            this.detailNewsService = detailNewsService;
            this.categoryNewsService = categoryNewsService;
        }

        public ActionResult Detail_NewsView()
        {
            List<Category_News> ListCategory = categoryNewsService.GetCategories();
            if (ListCategory != null)
                ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, string category, string state, int page = 1, int pageSize = 10)
        {
            var session = (UserLogin)Session[Constant.USER_SESSION];
            var model = detailNewsService.PageList(session.UserID.ToString() ,search, category, state, page, pageSize);
            return PartialView("Detail_NewsTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            List<Category_News> ListCategory = categoryNewsService.GetCategories();

            try
            {
                var data = detailNewsService.GetPostByID(Id);
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

                    if (data.Category_News == null)
                        ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
                    else
                        ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name", data.Category_News.Id);
                    return PartialView("CRUDDetail_News", model);
                }
            }
            catch (Exception)
            {
            }
            ViewBag.ListOfCategory = new SelectList(ListCategory, "Id", "Meta_Name");
            return PartialView("CRUDDetail_News", new DetailViewModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(DetailViewModel model)
        {
            var session = (UserLogin)Session[Constant.USER_SESSION];
            if (session == null)
                return RedirectToAction("Logon", "Login", new { Area = "Admin" });
            if (model.Id == null)
            {
                try
                {
                    Detail_News detail_Menu = new Detail_News()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Serial = model.Serial,
                        Status = model.Status.Equals(Gender.PUBLISH.ToString()) ? true : false,
                        Url_Image = model.Url_Image == null ? "#" : model.Url_Image,
                        Url_Video = model.Url_Video == null ? "#" : model.Url_Video,
                        Url_LinkGoogle = model.Url_LinkGoogle == null ? "#" : model.Url_LinkGoogle,
                        Category_News = context.Category_News.Find(new Guid(model.CategoryID)),
                        Create_At = DateTime.Now,
                        Update_At = DateTime.Now,
                        Account = context.Accounts.Find(session.UserID)
                    };

                    context.Detail_News.Add(detail_Menu);
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
                    var detail_Menu = detailNewsService.GetPostByID(model.Id);
                    detail_Menu.Title = model.Title;
                    detail_Menu.Description = model.Description;
                    detail_Menu.Content = model.Content;
                    detail_Menu.Serial = model.Serial;
                    detail_Menu.Status = model.Status.Equals(Gender.PUBLISH.ToString()) ? true : false;
                    detail_Menu.Url_Image = model.Url_Image == null ? "#" : model.Url_Image;
                    detail_Menu.Url_Video = model.Url_Video == null ? "#" : model.Url_Video;
                    detail_Menu.Url_LinkGoogle = model.Url_LinkGoogle == null ? "#" : model.Url_LinkGoogle;
                    detail_Menu.Update_At = DateTime.Now;
                    detail_Menu.Category_News = context.Category_News.Find(new Guid(model.CategoryID));
                    detail_Menu.Account = context.Accounts.Find(session.UserID);

                    //var data = utf8Convert3(detail_Menu.Title.ToLower()).Replace(" ", "-");
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
            return RedirectToAction("Detail_NewsView", "Detail_News");
        }

        // Chuyển đổi tiếng việt có dấu thành không dấu
        //public static string utf8Convert3(string s)
        //{
        //    Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        //    string temp = s.Normalize(NormalizationForm.FormD);
        //    return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        //}

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var detail_News = context.Detail_News.Find(new Guid(Id));
                context.Detail_News.Remove(detail_News);
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
                var post = detailNewsService.GetPostByID(Id);
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