using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.Filters
{
    public class ClaimsAuthorize : AuthorizeAttribute
    {
        private static string _claimName;
        private static string _claimValue;

        public ClaimsAuthorize(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            return claim != null && claim.Value.Contains(_claimValue);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}