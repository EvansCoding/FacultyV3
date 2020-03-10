using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FacultyV3.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly IDetailNewsService detailNewsService;
        private readonly ICategoryNewsService categoryNewsService;
        private readonly ICategoryMenuService categoryMenuService;
        private IDataContext context;
        public CommonController(IDetailNewsService detailNewsService, ICategoryNewsService categoryNewsService, ICategoryMenuService categoryMenuService, IDataContext context)
        {
            this.detailNewsService = detailNewsService;
            this.categoryMenuService = categoryMenuService;
            this.categoryNewsService = categoryNewsService;
            this.context = context;
        }

        public ActionResult _leftCategory()
        {
            var model = context.Category_News.Include(x => x.Children).Where(x => x.Parent == null).OrderBy(x => x.Meta_Name).ToList();
            return PartialView(model);
        }
    }
}