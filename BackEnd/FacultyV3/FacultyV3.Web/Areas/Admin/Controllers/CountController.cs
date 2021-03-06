﻿using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class CountController : BaseController
    {
        private readonly ICountService countService;

        public CountController(ICountService countService, IDataContext context) : base(context)
        {
            this.countService = countService;
        }
        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult CountView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = countService.GetCounts();
            return PartialView("CountTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = countService.GetCountByID(Id);
                if (data != null)
                {
                    var model = new CountViewModel();
                    model.Meta_Name = data.Meta_Name;
                    model.Meta_Value = data.Meta_Value;
                    return PartialView("CRUDCount", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDCount", new CountViewModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(CountViewModel model)
        {
            try
            {
                var count = countService.GetCountByID(model.Id);
                count.Meta_Value = model.Meta_Value;
                count.Update_At = DateTime.Now;

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