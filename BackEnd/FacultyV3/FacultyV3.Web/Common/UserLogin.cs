namespace FacultyV3.Web.Common
{
    using System;
    [Serializable]
    public class UserLogin
    {
        public Guid UserID { get; set; }
        public string Email { get; set; }
    }
}