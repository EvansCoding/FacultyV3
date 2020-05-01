using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class ConfirgurationController : Controller
    {
        private readonly IConfirgurationService confirgurationService;

        public ConfirgurationController(IConfirgurationService confirgurationService)
        {
            this.confirgurationService = confirgurationService;
        }
        // GET: Confirguration
        public ActionResult MessengerView()
        {
            var model = confirgurationService.GetConfirgurationByName(Constant.MESSENGER_NAME);
            return PartialView(model);
        }

        public PartialViewResult MetaView()
        {
            var meta_keywords = confirgurationService.GetConfirgurationByName(Constant.META_KEYWORDS);
            var meta_description = confirgurationService.GetConfirgurationByName(Constant.META_DESCRIPTION);

            if(meta_keywords != null & meta_description != null)
            {
                var model = new List<string>() { meta_keywords.Meta_Value, meta_description.Meta_Value };
                return PartialView(model);
            }
            return PartialView(null);
        }

        public JsonResult UpdateTotal()
        {
            var data = confirgurationService.UpdateTotal();
            var total = confirgurationService.GetConfirgurationByName(Constant.TOTAL_ACCESS);
           return Json(new { success = true, total = total.Meta_Value }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowTotal()
        {
            var total = confirgurationService.GetConfirgurationByName(Constant.TOTAL_ACCESS);
            return Json(new { success = true, total = total.Meta_Value }, JsonRequestBehavior.AllowGet);
        }
    }
}