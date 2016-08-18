using System.Web;
using System.Web.Mvc;

namespace MyTecBits_MVC5_Bootstrap3_EF6_DatabaseFirst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
