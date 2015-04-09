using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VPN.Web.Models;

namespace VPN.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private VPNWebContext db = new VPNWebContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.VpnInfoes.ToListAsync());
             
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