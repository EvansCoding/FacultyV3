using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class ConferenceController : BaseController
    {
        private readonly IConferenceService conferenceService;

        public ConferenceController(IConferenceService conferenceService, IDataContext context) : base(context)
        {
            this.conferenceService = conferenceService;
        }
        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult ConferenceView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = conferenceService.PageList(search, page, pageSize);
            return PartialView("ConferenceTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = conferenceService.GetConferenceByID(Id);
                if (data != null)
                {
                    var model = new ConferenceViewModel();
                    model.Title = data.Title;
                    model.Url_Image = data.Url_Image;
                    model.Url_Link = data.Url_Link;
                    model.Serial = data.Serial;
                    return PartialView("CRUDConference", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDConference", new ConferenceViewModel());
        }

        [HttpPost]
        public ActionResult AddOrUpdate(ConferenceViewModel model)
        {
            if (model.Id == null)
            {
                Conference conference = new Conference()
                {
                    Title = model.Title,
                    Url_Image = model.Url_Image,
                    Url_Link = model.Url_Link,
                    Serial = model.Serial,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Conferences.Add(conference);
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
                    var banner = conferenceService.GetConferenceByID(model.Id);
                    banner.Title = model.Title;
                    banner.Url_Image = model.Url_Image;
                    banner.Url_Link = model.Url_Link;
                    banner.Serial = model.Serial;
                    banner.Update_At = DateTime.Now;
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
            return RedirectToAction("ConferenceView", "Conference");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var conference = context.Conferences.Find(new Guid(Id));
                context.Conferences.Remove(conference);
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