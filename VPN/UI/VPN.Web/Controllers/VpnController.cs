using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VPN.Core.Entities;
using VPN.Web.Models;

namespace VPN.Web.Controllers
{
    public class VpnController : Controller
    {
        private VPNWebContext db = new VPNWebContext();

        // GET: /Vpn/
        public async Task<ActionResult> Index()
        {
            return View(await db.VpnInfoes.ToListAsync());
        }

        // GET: /Vpn/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
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
        public async Task<ActionResult> Create([Bind(Include="Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            if (ModelState.IsValid)
            {
                db.VpnInfoes.Add(vpninfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vpninfo);
        }

        // GET: /Vpn/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include="Id,Speed,IpAddress")] VpnInfo vpninfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vpninfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vpninfo);
        }

        // GET: /Vpn/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo);
        }

        // POST: /Vpn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            db.VpnInfoes.Remove(vpninfo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: /Vpn/Buy/5
        public async Task<ActionResult> Buy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            if (vpninfo == null)
            {
                return HttpNotFound();
            }
            return View(vpninfo); 
        }
        // POST: /Vpn/Buy/5
        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BuyConfirmed(int id)
        {
            VpnInfo vpninfo = await db.VpnInfoes.FindAsync(id);
            //db.VpnInfoes.Remove(vpninfo);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
