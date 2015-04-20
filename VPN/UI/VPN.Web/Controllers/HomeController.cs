using System.Web.Mvc;
using VPN.Core.IServices;
using VPN.Setting;

namespace VPN.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IVpnService vpnService = Ioc.Resolve<IVpnService>();

        public ActionResult Index()
        {

           // return View();
             return View(vpnService.FindList(x => x.Id != 0, "", false));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}