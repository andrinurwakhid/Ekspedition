using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ekspedition;

namespace Ekspedition.Controllers
{
    public class VillagesController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: Villages
        public async Task<ActionResult> Index()
        {
            var villages = db.Villages.Include(v => v.District);
            return View(await villages.ToListAsync());
        }

        // GET: Villages/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            return View(village);
        }

        // GET: Villages/Create
        public ActionResult Create()
        {
            ViewBag.District_Id = new SelectList(db.Districts, "Id", "Regency_Id");
            return View();
        }

        // POST: Villages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,District_Id,Name")] Village village)
        {
            if (ModelState.IsValid)
            {
                db.Villages.Add(village);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.District_Id = new SelectList(db.Districts, "Id", "Regency_Id", village.Districts_Id);
            return View(village);
        }

        // GET: Villages/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            ViewBag.District_Id = new SelectList(db.Districts, "Id", "Regency_Id", village.Districts_Id);
            return View(village);
        }

        // POST: Villages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,District_Id,Name")] Village village)
        {
            if (ModelState.IsValid)
            {
                db.Entry(village).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.District_Id = new SelectList(db.Districts, "Id", "Regency_Id", village.Districts_Id);
            return View(village);
        }

        // GET: Villages/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return HttpNotFound();
            }
            return View(village);
        }

        // POST: Villages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Village village = await db.Villages.FindAsync(id);
            db.Villages.Remove(village);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
