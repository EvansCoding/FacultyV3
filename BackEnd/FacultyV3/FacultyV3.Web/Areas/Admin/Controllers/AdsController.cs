using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Core.Models.Enums;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class AdsController : BaseController
    {
        private readonly IAdsService adsService;

        public AdsController(IAdsService adsService, IDataContext context) : base(context)
        {
            this.adsService = adsService;
        }

        public ActionResult AdsView()
        {
            var data = adsService.GetTop();

            if (data != null)
            {
                var model = new AdsViewModel()
                {
                    Id = data.Id.ToString(),
                    Url_Image = data.Url_Image,
                    Url_Link = data.Url_Link,
                    Status = data.Status ? Status.Publish.ToString() : Status.UnPublish.ToString(),
                    Create_At = data.Create_At,
                    Update_At = data.Update_At
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrUpdate(AdsViewModel model)
        {
            try
            {
                var Ads = adsService.GetAdsByID(model.Id);
                Ads.Url_Image = model.Url_Image;
                Ads.Url_Link = model.Url_Link;
                Ads.Status = model.Status.Equals(Status.Publish.ToString()) ? true : false;
                Ads.Update_At = DateTime.Now;

                context.SaveChanges();
                TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                {
                    Message = "Cập nhật thành công",
                    MessageType = GenericMessages.success
                };
            }
            catch (Exception)
            {
                TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                {
                    Message = "Lưu thất bại",
                    MessageType = GenericMessages.error
                };
            }
            return RedirectToAction("AdsView", "Ads");
        }
    }
}