using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VPN.Core.Entities;
using VPN.Core.IServices;
using VPN.Setting;

namespace VPN.Web.Controllers
{
    public class VpnController : Controller
    {
        private readonly IVpnService _vpnService = Ioc.Resolve<IVpnService>();

        // GET: /Vpn/
        public ActionResult Index()
        {
            return View(_vpnService.FindList(x => x.IsDeleted == false));
        }

        // GET: /Vpn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = _vpnService.Find(x => x.Id == id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
            return null;
        }

        // GET: /Vpn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vpn/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            if (ModelState.IsValid)
            {
                _vpnService.Insert(vpninfo);
                return RedirectToAction("Index");
            }

            //return View(vpninfo);
            return null;
        }

        // GET: /Vpn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = _vpnService.Find(x => x.Id == id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
        }

        // POST: /Vpn/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            if (ModelState.IsValid)
            {

                _vpnService.Update(vpninfo);
                return RedirectToAction("Index");
            }
            return View(vpninfo);
        }

        // GET: /Vpn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = _vpnService.Find(x => x.Id == id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
        }

        // POST: /Vpn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VpnInfo vpninfo = _vpnService.Find(x => x.Id == id);
            vpninfo.IsDeleted = true;
            _vpnService.Update(vpninfo);
            return RedirectToAction("Index");
        }

        // GET: /Vpn/Buy/5
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = _vpnService.Find(x => x.Id == id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
        }

        // POST: /Vpn/Buy/5
        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public ActionResult BuyConfirmed(int id)
        {
            var servervpn = Ioc.Resolve<IOrderService>();
            var userService = Ioc.Resolve<IUserService>();
            var order = new Order { Vpn = _vpnService.Find(x => x.Id == id) };
            int userId = int.Parse(User.Identity.GetUserId());
            order.User = userService.Find(x => x.Id == userId);
            servervpn.Insert(order);

            return RedirectToAction("Index", "Home");
        }

    }
}
