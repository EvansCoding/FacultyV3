using FacultyV3.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        public ActionResult ContactView()
        {
            var contact = contactService.GetContacts();
            if(contact != null)
            {
                ViewBag.Contact = contact;
            }
            return View();
        }
    }
}