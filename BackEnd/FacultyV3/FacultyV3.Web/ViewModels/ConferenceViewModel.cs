using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultyV3.Web.ViewModels
{
    public class ConferenceViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url_Image { get; set; }
        public string Url_Link { get; set; }
        public int Serial { get; set; }
    }
}