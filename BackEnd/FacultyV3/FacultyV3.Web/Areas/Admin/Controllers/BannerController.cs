using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerService bannerService;

        public BannerController(IBannerService bannerService, IDataContext context) : base(context)
        {
            this.bannerService = bannerService;
        }
        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult BannerView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = bannerService.PageList(search, page, pageSize);
            return PartialView("BannerTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = bannerService.GetBannerByID(Id);
                if (data != null)
                {
                    var model = new BannerViewModel();
                    model.Title = data.Title;
                    model.Title_Short = data.Title_Short;
                    model.Url_Image = data.Url_Image;
                    model.Url_Link = data.Url_Link;
                    model.Description = data.Description;
                    model.Serial = data.Serial;
                    return PartialView("CRUDBanner", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDBanner", new BannerViewModel());
        }

        [HttpPost]
        public ActionResult AddOrUpdate(BannerViewModel model)
        {
            if (model.Id == null)
            {
                Banner banner = new Banner()
                {
                    Title = model.Title,
                    Title_Short = model.Title_Short,
                    Url_Image = model.Url_Image,
                    Description = model.Description,
                    Url_Link = model.Url_Link,
                    Serial = model.Serial,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Banners.Add(banner);
                    context.SaveChanges();
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Thêm Banner thành công",
                        MessageType = GenericMessages.success
                    };
                }
                catch (Exception)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Thêm Banner thất bại",
                        MessageType = GenericMessages.error
                    };
                }
            }
            else
            {
                try
                {
                    var banner = bannerService.GetBannerByID(model.Id);
                    banner.Title = model.Title;
                    banner.Title_Short = model.Title_Short;
                    banner.Url_Image = model.Url_Image;
                    banner.Url_Link = model.Url_Link;
                    banner.Description = model.Description;
                    banner.Serial = model.Serial;
                    banner.Update_At = DateTime.Now;
                    context.SaveChanges();
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Cập nhật Banner thành công!",
                        MessageType = GenericMessages.success
                    };
                }
                catch (Exception)
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Cập nhật Banner thất bại!",
                        MessageType = GenericMessages.error
                    };
                }
            }
            return RedirectToAction("BannerView", "Banner");
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var banner = context.Banners.Find(new Guid(Id));
                context.Banners.Remove(banner);
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