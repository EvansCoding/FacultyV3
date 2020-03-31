using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Web.Mvc;
using System.Linq;


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

        public ActionResult ListNewss(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWSS, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListWorks(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.WORK, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListYouth_Group(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.YOUTH_GROUP, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListMinistry(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWS_FROM_THE_MINISTRY, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListFaculty(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWS_FROM_FACULTY, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListUniversity(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWS_FROM_UNIVERSITY, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListPartyCell(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWS_FROM_PARTY_CELL, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListUnion(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailNewsService.PageListFE(Constant.NEWS_FROM_UNION, page, pageSize);
                if (model.Count() > 0)
                    return View("ListDetailNews", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}