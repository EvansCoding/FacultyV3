using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class About_UsController : BaseController
    {
        private readonly IAbout_UsService about_UsService;

        public About_UsController(IAbout_UsService about_UsService, IDataContext context) : base(context)
        {
            this.about_UsService = about_UsService;
        }

        [HasCredential(RoleID = Constant.ADMIN)]
        public ActionResult About_UsView()
        {
            var data = about_UsService.GetTop();

            if (data != null)
            {
                var model = new About_UsViewModel()
                {
                    Id = data.Id.ToString(),
                    Content = data.Content,
                    Url_Video = data.Url_Video,
                    Create_At = data.Create_At,
                    Update_At = data.Update_At
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrUpdate(About_UsViewModel model)
        {
            try
            {
                var about_Us = about_UsService.GetAbout_UsByID(model.Id);
                about_Us.Content = model.Content;
                about_Us.Url_Video = model.Url_Video;
                about_Us.Update_At = DateTime.Now;

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
            return RedirectToAction("About_UsView", "About_Us");
        }
    }
}