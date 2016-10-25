using System.Web;
using System.Web.Mvc;

namespace MVC_Lab_Lesson11
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
