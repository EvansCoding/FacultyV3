using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Constants;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class VideoController : BaseController
    {
        private readonly IVideoService videoService;
        public VideoController(IVideoService videoService, IDataContext context) : base(context)
        {
            this.videoService = videoService;
        }
        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult VideoView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = videoService.PageList(search, page, pageSize);
            return PartialView("VideoTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = videoService.GetVideoByID(Id);
                if (data != null)
                {
                    var model = new VideoViewModel();
                    model.Title = data.Title;
                    model.Url_Image = data.Url_Image;
                    model.Url_Video = data.Url_Video;
                    model.Serial = data.Serial;
                    return PartialView("CRUDVideo", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDVideo", new VideoViewModel());
        }

        [HttpPost]
        public ActionResult AddOrUpdate(VideoViewModel model)
        {
            if (model.Id == null)
            {
                Video video = new Video()
                {
                    Title = model.Title,
                    Url_Image = model.Url_Image,
                    Url_Video = model.Url_Video,
                    Serial = model.Serial,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Videos.Add(video);
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
                    var Video = videoService.GetVideoByID(model.Id);

                    Video.Title = model.Title;
                    Video.Url_Image = model.Url_Image;
                    Video.Url_Video = model.Url_Video;
                    Video.Serial = model.Serial;
                    Video.Update_At = DateTime.Now;

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
            return RedirectToAction("VideoView", "Video");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var video = context.Videos.Find(new Guid(Id));
                context.Videos.Remove(video);
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