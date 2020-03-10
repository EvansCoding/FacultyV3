using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class Detail_NewsController : Controller
    {
        private readonly IDetailNewsService detailNewsService;
        private readonly ICategoryNewsService categoryNewsService;
        private readonly ICategoryMenuService categoryMenuService;
        private IDataContext context;

        public Detail_NewsController(IDetailNewsService detailNewsService, ICategoryNewsService categoryNewsService, ICategoryMenuService categoryMenuService, IDataContext context)
        {
            this.detailNewsService = detailNewsService;
            this.categoryMenuService = categoryMenuService;
            this.categoryNewsService = categoryNewsService;
            this.context = context;
        }

        public ActionResult DetailNews(string id)
        {
            try
            {
                var model = detailNewsService.GetPostByID(id);
                return View(model);
            }
            catch (Exception)
            {

            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListNewss()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.NEWSS);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListWorks()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.WORK);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListYouth_Group()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.YOUTH_GROUP);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListMinistry()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.NEWS_FROM_THE_MINISTRY);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListFaculty()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.NEWS_FROM_FACULTY);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListUniversity()
        {
            try
            {
                var model = detailNewsService.GetPostsByCategory(Constant.NEWS_FROM_UNIVERSITY);
                if (model.Count > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}