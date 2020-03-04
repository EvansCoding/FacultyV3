using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Core.Models.Entities;
using FacultyV3.Web.Common;
using FacultyV3.Web.ViewModels;
using System;
using System.Web.Mvc;

namespace FacultyV3.Web.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService, IDataContext context) : base(context)
        {
            this.contactService = contactService;
        }

        public ActionResult ContactView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTable(string search, int page = 1, int pageSize = 10)
        {
            var model = contactService.GetContacts();
            
            return PartialView("ContactTablePartialView", model);
        }

        public ActionResult AddOrEdit(string Id = "")
        {
            try
            {
                var data = contactService.GetContactByID(Id);
                if (data != null)
                {
                    var model = new ContactViewModel();
                    model.Meta_Name = data.Meta_Name;
                    model.Meta_Value = data.Meta_Value;
                    return PartialView("CRUDContact", model);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("CRUDContact", new ContactViewModel());
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrUpdate(ContactViewModel model)
        {
            if (model.Id == null)
            {
                Contact Contact = new Contact()
                {
                    Meta_Name = model.Meta_Name,
                    Meta_Value = model.Meta_Value,
                    Create_At = DateTime.Now,
                    Update_At = DateTime.Now
                };

                try
                {
                    context.Contacts.Add(Contact);
                    context.SaveChanges();

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    var contact = contactService.GetContactByID(model.Id);
                    contact.Meta_Name = model.Meta_Name;
                    contact.Meta_Value = model.Meta_Value;
                    contact.Update_At = DateTime.Now;
                    context.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                }

            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            try
            {
                var contact = context.Contacts.Find(new Guid(Id));
                context.Contacts.Remove(contact);
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