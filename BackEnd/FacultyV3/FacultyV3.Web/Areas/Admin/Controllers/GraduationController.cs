using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class GraduationController : BaseController
    {
        private readonly IGraduationService graduationService;
        public GraduationController(IGraduationService graduationService, IDataContext context) : base(context)
        {
            this.graduationService = graduationService;
        }

        public ActionResult GraduationView(string id)
        {
            var model = new GraduationViewModel();
            model.LecturerID = id;
            return View(model);
        }

        [HttpGet]
        public ActionResult LoadTable(string id)
        {
            var model = graduationService.GetGraduations(id);
            return PartialView("GraduationTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "", string lecturerID = "")
        {
            try
            {
                var data = graduationService.GetGraduationByID(Id);
                if (data != null)
                {
                    var model = new GraduationViewModel();
                    model.Degree = data.Degree;
                    model.Graduation_School = data.Graduation_School;
                    model.Graduation_Specialized = data.Graduation_Specialized;
                    model.Graduation_Year = data.Graduation_Year;
                    model.LecturerID = data.Lecturer.Id.ToString();
                    return PartialView("CRUDGraduation", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDGraduation", new GraduationViewModel() { LecturerID = lecturerID });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(GraduationViewModel model)
        {

            if (model.Id == null)
            {
                try
                {
                    Training_Process data = new Training_Process()
                    {
                        Degree = model.Degree,
                        Graduation_Year = model.Graduation_Year,
                        Graduation_School = model.Graduation_School,
                        Graduation_Specialized = model.Graduation_Specialized,
                        Lecturer = context.Lecturers.Include(x => x.Training_Processes).Where(x => x.Id == new Guid(model.LecturerID)).SingleOrDefault()
                    };

                    context.Training_Processes.Add(data);
                    context.SaveChanges();

                    return Json(new { success = true, message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { success = false, message = "Thêm thất bại" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                try
                {
                    var data = graduationService.GetGraduationByID(model.Id);
                    data.Degree = model.Degree;
                    data.Graduation_School = model.Graduation_School;
                    data.Graduation_Year = model.Graduation_Year;
                    data.Graduation_Specialized = model.Graduation_Specialized;
                    data.Lecturer = context.Lecturers.Include(x => x.Training_Processes).Where(x => x.Id == new Guid(model.LecturerID)).SingleOrDefault();

                    context.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { success = false, message = "Cập nhật thất bại" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var data = context.Training_Processes.Find(new Guid(Id));
                context.Training_Processes.Remove(data);
                context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}