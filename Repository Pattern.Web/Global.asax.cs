using System.Web.Mvc;
using System.Web.Routing;

namespace Repository_Pattern.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutofacConfig.Register();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}