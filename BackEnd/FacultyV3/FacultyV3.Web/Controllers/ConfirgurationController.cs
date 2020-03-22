using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces.IServices;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class ConfirgurationController : Controller
    {
        private readonly IConfirgurationService confirgurationService;

        public ConfirgurationController(IConfirgurationService confirgurationService)
        {
            this.confirgurationService = confirgurationService;
        }
        // GET: Confirguration
        public ActionResult MessengerView()
        {
            var model = confirgurationService.GetConfirgurationByName(Constant.MESSENGER_NAME);
            return PartialView(model);
        }
    }
}