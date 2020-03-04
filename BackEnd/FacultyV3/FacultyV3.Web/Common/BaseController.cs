using FacultyV3.Core.Interfaces;
using System.Web.Mvc;

namespace FacultyV3.Web.Common
{
    public class BaseController : Controller
    {
        protected readonly IDataContext context;

        public BaseController(IDataContext context)
        {
            this.context = context;
        }
    }
}