using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class CategoryMenuController : BaseController
    {
        public readonly ICategoryMenuService categoryMenuService;

        public CategoryMenuController(ICategoryMenuService categoryMenuService, IDataContext context) : base(context)
        {
            this.categoryMenuService = categoryMenuService;
        }

        public ActionResult CategoryMenuView()
        {
            return View();
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            List<Category_Menu> ListParent = context.Category_Menus.ToList();
            //List<Category_Menu> ListParent = context.Category_Menus.Where(x => !x.Detail_Menus.Any() ).ToList();
            try
            {
                var data = categoryMenuService.GetCategoryByID(Id);

                    var model = new Category_MenuViewModel();
                    model.Id = data.Id.ToString();
                    model.Meta_Name = data.Meta_Name;
                    model.Meta_Value = data.Meta_Value;
                    model.Serial = data.Serial;
                    if (data.Parent == null)
                        ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name");
                    else
                        ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name", data.Parent.Id);
                    return PartialView("CRUDCategoryMenu", model);
                
            }
            catch (Exception)
            {
            }
            ViewBag.ListOfParent = new SelectList(ListParent, "Id", "Meta_Name");
            return PartialView("CRUDCategoryMenu", new Category_MenuViewModel());

        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = categoryMenuService.PageList(search, page, pageSize);
            return PartialView("CategoryMenuTablePartialView", model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(Category_MenuViewModel model)
        {
            var parent = categoryMenuService.GetCategoryByID(model.ParentID);
            var meta_name = context.Category_Menus.Where(x => x.Meta_Name.Contains(model.Meta_Name)).ToList();



            if (model.Id == null)
            {
                if (meta_name.Count > 0)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Tên danh mục đã tồn tại!",
                        MessageType = GenericMessages.error
                    };

                    return RedirectToAction("CategoryMenuView", "CategoryMenu");
                }

                try
                {
                    Category_Menu category = new Category_Menu()
                    {
                        Meta_Name = model.Meta_Name,
                        Meta_Value = model.Meta_Value,
                        Serial = model.Serial,
                        Parent = parent,
                        Create_At = DateTime.Now,
                        Update_At = DateTime.Now
                    };

                    context.Category_Menus.Add(category);
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


                    var category = categoryMenuService.GetCategoryByID(model.Id);

                    if (!category.Meta_Name.Equals(model.Meta_Name))
                    {
                        if (meta_name.Count > 0)
                        {
                            TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                            {
                                Message = "Tên danh mục đã tồn tại!",
                                MessageType = GenericMessages.error
                            };

                            return RedirectToAction("CategoryMenuView", "CategoryMenu");
                        }
                        else
                        {
                            category.Meta_Name = model.Meta_Name;
                        }
                    }

                    category.Meta_Value = model.Meta_Value;
                    category.Parent = parent;
                    category.Serial = model.Serial;
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
            return RedirectToAction("CategoryMenuView", "CategoryMenu");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var category = context.Category_Menus.Find(new Guid(Id));
                context.Category_Menus.Remove(category);
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