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
    public class RegenciesController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: Regencies
        public async Task<ActionResult> Index()
        {
            var regencies = db.Regencies.Include(r => r.Province);
            return View(await regencies.ToListAsync());
        }

        // GET: Regencies/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            return View(regency);
        }

        // GET: Regencies/Create
        public ActionResult Create()
        {
            ViewBag.Province_Id = new SelectList(db.Provinces, "Id", "Name");
            return View();
        }

        // POST: Regencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Province_Id,Name")] Regency regency)
        {
            if (ModelState.IsValid)
            {
                db.Regencies.Add(regency);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Province_Id = new SelectList(db.Provinces, "Id", "Name", regency.Province_Id);
            return View(regency);
        }

        // GET: Regencies/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            ViewBag.Province_Id = new SelectList(db.Provinces, "Id", "Name", regency.Province_Id);
            return View(regency);
        }

        // POST: Regencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Province_Id,Name")] Regency regency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Province_Id = new SelectList(db.Provinces, "Id", "Name", regency.Province_Id);
            return View(regency);
        }

        // GET: Regencies/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regency regency = await db.Regencies.FindAsync(id);
            if (regency == null)
            {
                return HttpNotFound();
            }
            return View(regency);
        }

        // POST: Regencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Regency regency = await db.Regencies.FindAsync(id);
            db.Regencies.Remove(regency);
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
