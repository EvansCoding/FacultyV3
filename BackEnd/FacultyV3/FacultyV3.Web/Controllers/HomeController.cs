﻿using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System.Web.Mvc;
using System.Web.Routing;

namespace FacultyV3.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataContext context;
        private readonly IAbout_UsService about_UsService;
        private readonly IBannerService bannerService;
        private readonly ICategoryMenuService categoryMenuService;
        private readonly ICategoryNewsService categoryNewsService;
        private readonly IContactService contactService;
        private readonly ICountService countService;
        private readonly IDescriptionService descriptionService;
        private readonly ILecturerService lecturerService;
        private readonly IStickyService stickyService;
        private readonly IStudentService studentService;
        private readonly IVideoService videoService;
        private readonly IAdsService adsService;
        private readonly IDetailNewsService detailNewsService;
        private readonly IConfirgurationService confirgurationService;
        private readonly IConferenceService conferenceService;

        public HomeController(IDataContext context, IAbout_UsService about_UsService, IBannerService bannerService, ICategoryMenuService categoryMenuService,
            ICategoryNewsService categoryNewsService, IContactService contactService, ICountService countService, IDescriptionService descriptionService,
            ILecturerService lecturerService, IStickyService stickyService, IStudentService studentService, IVideoService videoService, IAdsService adsService, 
            IDetailNewsService detailNewsService, IConfirgurationService confirgurationService, IConferenceService conferenceService)
        {
            this.context = context;
            this.about_UsService = about_UsService;
            this.bannerService = bannerService;
            this.categoryMenuService = categoryMenuService;
            this.categoryNewsService = categoryNewsService;
            this.contactService = contactService;
            this.countService = countService;
            this.descriptionService = descriptionService;
            this.lecturerService = lecturerService;
            this.stickyService = stickyService;
            this.studentService = studentService;
            this.videoService = videoService;
            this.adsService = adsService;
            this.detailNewsService = detailNewsService;
            this.confirgurationService = confirgurationService;
            this.conferenceService = conferenceService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _aboutus()
        {
            var model = about_UsService.GetTop();

            return PartialView(model);
        }

        public ActionResult _counter()
        {
            var model = countService.GetCounts();

            return PartialView(model);
        }

        public ActionResult _description()
        {
            var model = descriptionService.GetServices();
            return PartialView(model);
        }

        public ActionResult _generalNews()
        {
            var model = detailNewsService.GetPostTop(6);
            return PartialView(model);
        }

        public ActionResult _news()
        {

            return PartialView();
        }

        public ActionResult _ads()
        {
            var model = adsService.ShowUI();
            return PartialView(model);
        }
        public ActionResult _slider()
        {
            var model = bannerService.GetBannersOrderBySerial(5);

            return PartialView(model);
        }

        public ActionResult _student()
        {
            var model = studentService.GetStudentOrderBySerial(3);
            return PartialView(model);
        }

        public ActionResult _teacher()
        {
            var model = lecturerService.GetStudentOrderBySerial(4);
            return PartialView(model);
        }

        public ActionResult _video()
        {
            var model = videoService.GetVideosOrderBySerial(3);
            return PartialView(model);
        }
       
        public ActionResult _conference()
        {
            var model = conferenceService.GetConferencesOrderBySerial(3);
            return PartialView(model);
        }
        public ActionResult _menu()
        {
            // Get Children Category Intro
            var intro = categoryMenuService.GetCategoriesByParent(Constant.INTRODUCE);
            if (intro != null)
                ViewBag.intro = intro;

            var admission = categoryMenuService.GetCategoryByName(Constant.ADMISSION);
            if (admission != null)
                ViewBag.admission = admission;

            var educate = categoryMenuService.GetCategoriesByParent(Constant.EDUCATE);
            if (educate != null)
                ViewBag.educate = educate;

            var research = categoryMenuService.GetCategoriesByParent(Constant.RESEARCH);
            if (research != null)
                ViewBag.research = research;

            var resource = categoryMenuService.GetCategoryByName(Constant.RESOURCE);
            if (resource != null)
                ViewBag.resource = resource;

            var party_cell = categoryMenuService.GetCategoryByName(Constant.PARTY_CELL);
            if (party_cell != null)
                ViewBag.party_cell = party_cell;

            var alumni = categoryMenuService.GetCategoriesByParent(Constant.STUDENT);
            if (alumni != null)
                ViewBag.alumni = alumni;

            var language = stickyService.GetStickyByID("EE5AC888-CBD3-4843-8775-AB7300D6369A");
            if (language != null)
                ViewBag.Language = language;
            return PartialView();
        }

        public ActionResult _footer()
        {
            ViewBag.Department = categoryMenuService.GetCategoryByName(Constant.DEPARTMENT).Children;
            ViewBag.Contact = contactService.GetContacts();

            // Get total access from db
            var total = confirgurationService.GetConfirgurationByName(Constant.TOTAL_ACCESS);
            ViewBag.Total = long.Parse(total.Meta_Value);
            return PartialView();
        }

        public ActionResult _sticky()
        {
            var model = stickyService.GetStickys();
            return PartialView(model);
        }
    }
}