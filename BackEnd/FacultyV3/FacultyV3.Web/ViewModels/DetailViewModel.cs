using System;

namespace FacultyV3.Web.ViewModels
{
    public class DetailViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Serial { get; set; }
        public string Status { get; set; }
        public string Url_Image { get; set; }
        public string Url_Video { get; set; }
        public string Url_LinkGoogle { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
        public string CategoryID { get; set; }
        public string AccountID { get; set; }
    }
}