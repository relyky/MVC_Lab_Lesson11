using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Helpers;

using System.Diagnostics;

namespace MVC_Lab_Lesson11
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 變更 AntiForgery 預設 cookie 名稱
            AntiForgeryConfig.CookieName = "My_AntiForgery_Cookie";
            AntiForgeryConfig.AdditionalDataProvider = new MyAntiForgeryExtension();
        }
    }

    public class MyAntiForgeryExtension : IAntiForgeryAdditionalDataProvider
    {
        public string GetAdditionalData(HttpContextBase context)
        {
            Debug.WriteLine("ON : GetAdditionalData()... =======================================");
            return DateTime.UtcNow.Ticks.ToString();
        }

        public bool ValidateAdditionalData(HttpContextBase context, string additionalData)
        {
            Debug.WriteLine("ON : ValidateAdditionalData()...=======================================");

            if (string.IsNullOrWhiteSpace(additionalData))
                return false;

            var requestTime = Convert.ToInt64(additionalData);
            var now = DateTime.UtcNow.Ticks;
            var difference = new TimeSpan(now - requestTime);
            return (difference.TotalMinutes > -1 && difference.TotalMinutes < 10);
        }

    }


}
