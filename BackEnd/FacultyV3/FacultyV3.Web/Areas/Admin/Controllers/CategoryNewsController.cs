using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class CategoryNewsController : BaseController
    {
        public readonly ICategoryNewsService categoryNewsService;

        public CategoryNewsController(ICategoryNewsService categoryNewsService, IDataContext context) : base(context)
        {
            this.categoryNewsService = categoryNewsService;
        }

        public ActionResult CategoryNewsView()
        {
            return View();
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            List<Category_News> ListParent = context.Category_News.Where(x => !x.Detail_Newss.Any()).ToList();
            try
            {
                var data = categoryNewsService.GetCategoryByID(Id);

                var model = new Category_NewsViewModel();
                model.Id = data.Id.ToString();
                model.Meta_Name = data.Meta_Name;
                model.Meta_Value = data.Meta_Value;
                model.Serial = data.Serial;
                if (data.Parent == null)
                    ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name");
                else
                    ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name", data.Parent.Id);
                return PartialView("CRUDCategoryNews", model);

            }
            catch (Exception)
            {
            }
            ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name");
            return PartialView("CRUDCategoryNews", new Category_NewsViewModel());

        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = categoryNewsService.PageList(search, page, pageSize);
            return PartialView("CategoryNewsTablePartialView", model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(Category_NewsViewModel model)
        {
            var parent = categoryNewsService.GetCategoryByID(model.ParentID);
            var meta_name = context.Category_News.Where(x => x.Meta_Name.Contains(model.Meta_Name)).ToList();

            if (meta_name.Count > 0)
            {
                TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                {
                    Message = "Tên danh mục đã tồn tại!",
                    MessageType = GenericMessages.error
                };

                return RedirectToAction("CategoryNewsView", "CategoryNews"); ;
            }
            if (model.Id == null )
            {
                try
                {
                    Category_News category = new Category_News()
                    {
                        Meta_Name = model.Meta_Name,
                        Meta_Value = model.Meta_Value,
                        Parent = parent,
                        Create_At = DateTime.Now,
                        Update_At = DateTime.Now
                    };

                    context.Category_News.Add(category);
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
                    var category = categoryNewsService.GetCategoryByID(model.Id);
                    category.Meta_Name = model.Meta_Name;
                    category.Meta_Value = model.Meta_Value;
                    category.Parent = parent;
                    category.Update_At = DateTime.Now;

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
            return RedirectToAction("CategoryNewsView", "CategoryNews");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var category = context.Category_News.Find(new Guid(Id));
                context.Category_News.Remove(category);
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