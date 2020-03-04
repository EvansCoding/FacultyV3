using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultyV3.Web.ViewModels
{
    public class AdsViewModel
    {
        public string Id { get; set; }
        public string Url_Image { get; set; }   
        public string Url_Link { get; set; }
        public string Status { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}