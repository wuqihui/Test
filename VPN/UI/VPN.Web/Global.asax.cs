using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NHibernate.Context;
using VPN.Setting;

namespace VPN.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Ioc.Instance.StartUp(new Bootstrapper());
        }
        protected void Application_BeginRequest()
        {
            var session = Ioc.Instance.SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest()
        {
            CurrentSessionContext.Unbind(Ioc.Instance.SessionFactory);
        }

        protected void Application_OnEnd()
        {
            Ioc.Instance.Container.Dispose();
        }
    }
}
