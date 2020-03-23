using System;

namespace FacultyV3.Web.ViewModels
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Create_At { get; set; } 
        public DateTime Update_At { get; set; }
    }
}