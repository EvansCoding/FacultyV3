using System;
using System.Web.Mvc;

namespace FacultyV3.Web.ViewModels
{
    public class About_UsViewModel
    {
        public string Id { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public string Url_Video { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}