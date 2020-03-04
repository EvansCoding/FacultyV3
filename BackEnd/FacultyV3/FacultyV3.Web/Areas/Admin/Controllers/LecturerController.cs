using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class LecturerController : BaseController
    {
        private readonly ILecturerService lecturerService;

        public LecturerController(ILecturerService lecturerService, IDataContext context) : base(context)
        {
            this.lecturerService = lecturerService;
        }

        public ActionResult LecturerView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = lecturerService.PageList(search, page, pageSize);
            return PartialView("LecturerTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = lecturerService.GetLecturerByID(Id);
                if (data != null)
                {
                    var model = new LecturerViewModel();
                    model.FullName = data.FullName;
                    model.Degree = data.Degree;
                    model.Url_Image = data.Url_Image;
                    model.Url_Facebook = data.Url_Facebook;
                    model.Phone = data.Phone;
                    model.Email = data.Email;
                    model.Serial = data.Serial;
                    return PartialView("CRUDLecturer", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDLecturer", new LecturerViewModel());
        }


        [HttpPost]
        public ActionResult AddOrUpdate(LecturerViewModel model)
        {
            if (model.Id == null)
            {
                Lecturer lecturer = new Lecturer()
                {
                    FullName = model.FullName,
                    Degree = model.Degree,
                    Url_Image = model.Url_Image,
                    Url_Facebook = model.Url_Facebook,
                    Phone = model.Phone,
                    Email = model.Email,
                    Serial = model.Serial,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Lecturers.Add(lecturer);
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
                    var lecturer = lecturerService.GetLecturerByID(model.Id);

                    lecturer.FullName = model.FullName;
                    lecturer.Degree = model.Degree;
                    lecturer.Url_Image = model.Url_Image;
                    lecturer.Url_Facebook = model.Url_Facebook;
                    lecturer.Phone = model.Phone;
                    lecturer.Email = model.Email;
                    lecturer.Serial = model.Serial;
                    lecturer.Update_At = DateTime.Now;

                    context.SaveChanges();

                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Sửa thành công!",
                        MessageType = GenericMessages.success
                    };
                }
                catch (Exception)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Sửa thất bại!",
                        MessageType = GenericMessages.error
                    };
                }
            }
            return RedirectToAction("LecturerView", "Lecturer");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var lecturer = context.Lecturers.Find(new Guid(Id));
                context.Lecturers.Remove(lecturer);
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