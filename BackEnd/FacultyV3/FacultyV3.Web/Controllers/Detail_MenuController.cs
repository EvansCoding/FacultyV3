﻿using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System.Linq;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class Detail_MenuController : Controller
    {
        private readonly IDetailMenuService detailMenuService;
        private readonly ICategoryNewsService categoryNewsService;
        private readonly ICategoryMenuService categoryMenuService;
        private IDataContext context;
        public Detail_MenuController(IDetailMenuService detailMenuService, ICategoryNewsService categoryNewsService, ICategoryMenuService categoryMenuService, IDataContext context)
        {
            this.detailMenuService = detailMenuService;
            this.categoryMenuService = categoryMenuService;
            this.categoryNewsService = categoryNewsService;
            this.context = context;
        }

        public ActionResult DetailMenu(string id)
        {
            try
            {
                var model = detailMenuService.GetPostByID(id);
                if(model != null)
                return View(model);
            }
            catch (System.Exception)
            {

            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult _leftCategory()
        {
            try
            {
                //var model = context.Category_News.Where(x => x.Meta_Name.Equals(Constant.NEWS)).SingleOrDefault();

            }
            catch (System.Exception)
            {
            }
            return View();
        }

        public ActionResult ListDepartment(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.DEPARTMENT, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListEducation_Program(int page = 1, int pageSize = 6)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.EDUCATION_PROGRAM, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListTraining_Sector(int page = 1, int pageSize = 6)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.TRAINING_SECTOR, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListResource(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.RESOURCE, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailResource", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListAdmission(int page = 1, int pageSize = Constant.PAGESIZEADMISSION)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.ADMISSION, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListConference(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.CONFERENCE, page, pageSize);
                if (Enumerable.Count( model) > 0)
                    return View("ListDetailConference", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListForm(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.FORM, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailForm", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListNoteBook(int page = 1, int pageSize = Constant.PAGESIZE)
        {
            try
            {
                var model = detailMenuService.PageListFE(Constant.NOTEBOOK, page, pageSize);
                if (Enumerable.Count(model) > 0)
                    return View("ListDetailResource", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}