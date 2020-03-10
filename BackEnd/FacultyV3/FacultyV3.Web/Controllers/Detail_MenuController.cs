using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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

        public ActionResult ListDepartment()
        {
            try
            {
                var model = detailMenuService.GetPostsByCategory(Constant.DEPARTMENT);
                if (model.Count > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListEducation_Program()
        {
            try
            {
                var model = detailMenuService.GetPostsByCategory(Constant.EDUCATION_PROGRAM);
                if (model.Count > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListTraining_Sector()
        {
            try
            {
                var model = detailMenuService.GetPostsByCategory(Constant.TRAINING_SECTOR);
                if (model.Count > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListResource()
        {
            try
            {
                var model = detailMenuService.GetPostsByCategory(Constant.RESOURCE);
                if (model.Count > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult ListAdmission()
        {
            try
            {
                var model = detailMenuService.GetPostsByCategory(Constant.ADMISSION);
                if (model.Count > 0)
                    return View("ListDetailMenu", model);
            }
            catch (System.Exception)
            {
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}