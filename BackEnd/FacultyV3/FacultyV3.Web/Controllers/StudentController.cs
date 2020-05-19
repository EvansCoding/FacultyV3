using FacultyV3.Core.Interfaces;
using FacultyV3.Core.Interfaces.IServices;
using FacultyV3.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Controllers
{
    public class StudentController : Controller
    {
        private IDataContext context;
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService, IDataContext context)
        {
            this.studentService = studentService;
            this.context = context;
        }
        public ActionResult StudentView()
        {
            var data = context.Students.OrderByDescending(x => x.Serial).ToList();
            return View(data);
        }
    }
}