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
    public class StudentController : BaseController
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService, IDataContext context) : base(context)
        {
            this.studentService = studentService;
        }
        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult StudentView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = studentService.PageList(search, page, pageSize);
            return PartialView("StudentTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = studentService.GetStudentByID(Id);
                if (data != null)
                {
                    var model = new StudentViewModel();
                    model.FullName = data.FullName;
                    model.Url_Image = data.Url_Image;
                    model.Content = data.Content;
                    model.Serial = data.Serial;
                    return PartialView("CRUDStudent", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDStudent", new StudentViewModel());
        }

        [HttpPost]
        public ActionResult AddOrUpdate(StudentViewModel model)
        {
            if (model.Id == null)
            {
                Student Student = new Student()
                {
                    FullName = model.FullName,
                    Url_Image = model.Url_Image,
                    Content = model.Content,
                    Serial = model.Serial,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Students.Add(Student);
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
                    var student = studentService.GetStudentByID(model.Id);
                    student.FullName = model.FullName;
                    student.Url_Image = model.Url_Image;
                    student.Content = model.Content;
                    student.Serial = model.Serial;
                    student.Update_At = DateTime.Now;

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
            return RedirectToAction("StudentView", "Student");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var student = context.Students.Find(new Guid(Id));
                context.Students.Remove(student);
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