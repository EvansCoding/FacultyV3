using FacultyV3.Core.Interfaces;
using FacultyV3.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.ViewModels;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class ConfirgurationController : BaseController
    {
        private readonly IConfirgurationService confirgurationService;
        
        public ConfirgurationController(IConfirgurationService confirgurationService, IDataContext context) : base(context)
        {
            this.confirgurationService = confirgurationService;
        }

        public ActionResult ConfirgurationView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable()
        {
            var model = confirgurationService.GetConfirgurations();
            return PartialView("ConfirgurationTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = confirgurationService.GetConfirgurationByID(Id);
                if (data != null)
                {
                    var model = new ConfirgurationViewModel();
                    model.Meta_Name = data.Meta_Name;
                    model.Meta_Value = data.Meta_Value;
                    return PartialView("CRUDConfirguration", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDConfirguration", new ConfirgurationViewModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(ConfirgurationViewModel model)
        {
            try
            {
                var stickey = confirgurationService.GetConfirgurationByID(model.Id);
                stickey.Meta_Value = model.Meta_Value;
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