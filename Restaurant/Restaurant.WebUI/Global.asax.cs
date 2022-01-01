using Restaurant.WebUI.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Restaurant.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                LogInfo log = new LogInfo
                {
                    Url = Request.Url.ToString(),
                    HataMesajı = httpException.Message,
                    EklenmeTarihi = DateTime.Now,
                    Tarayici = Request.Browser.Browser,
                    Dil = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2)
                };

                switch (httpException.GetHashCode())
                {
                    case 400:
                        Response.Redirect("/Erorr/NotFound/");
                        break;
                    case 403:
                        Response.Redirect("/Erorr/NotFound/");
                        break;
                    case 404:
                        Response.Redirect("/Erorr/NotFound/");
                        break;
                    case 500:
                        Response.Redirect("/Erorr/NotFound/");
                        break;
                    case 503:
                        Response.Redirect("/Erorr/NotFound/");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
