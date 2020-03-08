using System;

namespace FacultyV3.Web.ViewModels
{
    public class Category_NewsViewModel
    {
        public string Id { get; set; }
        public string Meta_Name { get; set; }
        public string Meta_Value { get; set; }
        public int Serial { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
        public string ParentID { get; set; }
    }
}