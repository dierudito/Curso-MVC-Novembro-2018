using System.Web.Mvc;
using EP.CursoMvc.Infra.CrossCutting.Filters;

namespace EP.CursoMvc.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
