using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using VPN.Core.Entities;
using VPN.Core.IServices;
using VPN.Setting;

namespace VPN.Web.Controllers
{
    public class VpnController : Controller
    {
        private IVpnService vpnService = Ioc.Resolve<IVpnService>();

        // GET: /Vpn/
        public  ActionResult  Index()
        {
             return View(vpnService.FindList(x=>x.IsDeleted==false,"Speed",false) );
        }

        // GET: /Vpn/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            //if (vpninfo == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vpninfo);
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
        public  ActionResult  Create([Bind(Include="Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            if (ModelState.IsValid)
            {
                vpnService.Insert(vpninfo);
                return RedirectToAction("Index");
            }

            //return View(vpninfo);
            return null;
        }

        // GET: /Vpn/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            //if (vpninfo == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vpninfo);
            return null;
        }

        // POST: /Vpn/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(vpninfo).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(vpninfo);
            return null;
        }

        // GET: /Vpn/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            //if (vpninfo == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vpninfo);
            return null;
        }

        // POST: /Vpn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            //db.VpnInfoes.Remove(vpninfo);
            //await db.SaveChangesAsync();
            //return RedirectToAction("Index");
            return null;
        }
        // GET: /Vpn/Buy/5
        public ActionResult Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo =vpnService.Find(x=>x.Id==id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo); 
            return null;
        }
        // POST: /Vpn/Buy/5
        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public ActionResult BuyConfirmed(int id)
        {
            
            var servervpn = Ioc.Resolve<IUserService>();
            Order order=new Order();
            order.Vpn = vpnService.Find(x => x.Id == id);
            order.User =servervpn.Find(x => x.Id==id);
            servervpn.SaveOrders(order);

            return RedirectToAction("Index","Home");
        }

    }
}
