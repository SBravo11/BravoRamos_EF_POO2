using System.Web;
using System.Web.Mvc;

namespace BravoRamos_EF_POO2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
