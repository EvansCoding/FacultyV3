using FacultyV3.Core.Constants;
using System.Web;
using System.Web.Mvc;

namespace FacultyV3.Web.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[Constant.USER_SESSION];
            if (session == null)
                return false;
            string privilegeLevels = this.GetCredentialByLoggedInUser(session.Email);
            if (privilegeLevels.Contains(this.RoleID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error401.cshtml"
            };
        }
        private string GetCredentialByLoggedInUser(string email)
        {
            var credential = (string)HttpContext.Current.Session[Constant.SESSION_CREDENTIAL];
            return credential;
        }
    }
}