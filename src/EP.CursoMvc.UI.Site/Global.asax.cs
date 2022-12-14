using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EP.CursoMvc.Application.AutoMapper;

namespace EP.CursoMvc.UI.Site
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
