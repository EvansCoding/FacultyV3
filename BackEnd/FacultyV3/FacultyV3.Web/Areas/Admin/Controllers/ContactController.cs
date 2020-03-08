using FacultyV3.Core.Constants;
using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
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
                    if(model.Meta_Name.Equals("Hình ảnh"))
                    {
                        return PartialView("CRUDImage", model);
                    }
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
            string name = "";
            try
            {
                var contact = contactService.GetContactByID(model.Id);
                name = contact.Meta_Name;
                contact.Meta_Value = model.Meta_Value;
                contact.Update_At = DateTime.Now;
                context.SaveChanges();

                if (contact.Meta_Name.Equals("Hình ảnh"))
                {
                    TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Cập nhật thành công!",
                        MessageType = GenericMessages.success
                    };
                    return RedirectToAction("ContactView", "Contact");
                }
                    
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }

            if (name.Equals("Hình ảnh"))
            {
                TempData[Constant.MessageViewBagName] = new GenericMessageViewModel
                {
                    Message = "Cập nhật thất bại!",
                    MessageType = GenericMessages.error
                };
                return RedirectToAction("ContactView", "Contact");
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}