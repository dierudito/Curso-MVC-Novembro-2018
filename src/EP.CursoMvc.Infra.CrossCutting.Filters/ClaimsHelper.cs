using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMvc.Infra.CrossCutting.Filters
{
    public static class ClaimsHelper
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue);
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            return ValidarClaimsUsuario(claimName, claimValue) ? "" : "disabled";
        }

        private static bool ValidarClaimsUsuario(string claimName, string claimValue)
        {
            return true;
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}