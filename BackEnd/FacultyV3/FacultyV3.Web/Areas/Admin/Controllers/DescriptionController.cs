using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class DescriptionController : BaseController
    {
        private readonly IDescriptionService descriptionService;

        public DescriptionController(IDescriptionService descriptionService, IDataContext context) : base(context)
        {
            this.descriptionService = descriptionService;
        }

        public ActionResult DescriptionView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = context.Services.Select(x => x).ToList();
            return PartialView("DescriptionTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = descriptionService.GetServiceByID(Id);
                if (data != null)
                {
                    var model = new DescriptionViewModel();
                    model.Meta_Name = data.Meta_Name;
                    model.Meta_Value = data.Meta_Value;
                    return PartialView("CRUDDescription", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDDescription", new DescriptionViewModel());

        }


        [HttpPost]
        public ActionResult AddOrUpdate(DescriptionViewModel model)
        {
            if (model.Id == null)
            {
                Service service = new Service()
                {
                    Meta_Name = model.Meta_Name,
                    Meta_Value = model.Meta_Value,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Services.Add(service);
                    context.SaveChanges();

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                }

                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var service = descriptionService.GetServiceByID(model.Id);
                    service.Meta_Name = model.Meta_Name;
                    service.Meta_Value = model.Meta_Value;
                    service.Update_At = DateTime.Now;

                    context.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var service = context.Services.Find(new Guid(Id));
                context.Services.Remove(service);
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