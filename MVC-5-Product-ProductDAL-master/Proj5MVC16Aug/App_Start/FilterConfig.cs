using System.Web;
using System.Web.Mvc;

namespace Proj5MVC16Aug
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
