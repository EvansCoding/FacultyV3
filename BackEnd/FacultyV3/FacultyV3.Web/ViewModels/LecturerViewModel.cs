using System;

namespace FacultyV3.Web.ViewModels
{
    public class LecturerViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Degree { get; set; }
        public string Url_Image { get; set; }
        public string Url_Facebook { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Serial { get; set; }
        public string Position { get; set; }
        public string Academic_Rank { get; set; }
        public string Specialized { get; set; }
        public string Title { get; set; }
        public string Native_Land { get; set; }
        public string Url_Scientific_Works { get; set; }
        public string Specialized_Research { get; set; }
        public string Teaching { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}