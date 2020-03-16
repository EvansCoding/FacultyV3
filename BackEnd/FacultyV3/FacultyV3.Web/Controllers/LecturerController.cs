using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ILecturerService lecturerService;
        private IDataContext context;

        public LecturerController(ILecturerService lecturerService, IDataContext context)
        {
            this.lecturerService = lecturerService;
            this.context = context;
        }
        public ActionResult LecturerView()
        {
            return View();
        }

        public ActionResult LoadTable(string search, int page = 1, int pageSize = 8)
        {
            try
            {
                var model = lecturerService.PageList(search, page, pageSize);
                if (model != null)
                    return PartialView("LecturerTablePartialView", model);
            }
            catch (Exception)
            {
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult DetailLecturer(string Id = "")
        {
            try
            {
                var model = lecturerService.GetLecturerByID(Id);
                if (model != null)
                    return PartialView("DetailLecturer", model);
            }
            catch (Exception)
            {
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}