using System;

namespace FacultyV3.Web.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Url_Image { get; set; }
        public string Content { get; set; }
        public string Course { get; set; }
        public string Major { get; set; }
        public string Graduation_Year { get; set; }
        public string Current_Job { get; set; }
        public string Work_Place { get; set; }
        public int Serial { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}