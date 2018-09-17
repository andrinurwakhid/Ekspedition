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
    public class StatusShippingsController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: StatusShippings
        public async Task<ActionResult> Index()
        {
            return View(await db.StatusShippings.ToListAsync());
        }

        // GET: StatusShippings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusShipping statusShipping = await db.StatusShippings.FindAsync(id);
            if (statusShipping == null)
            {
                return HttpNotFound();
            }
            return View(statusShipping);
        }

        // GET: StatusShippings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusShippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] StatusShipping statusShipping)
        {
            if (ModelState.IsValid)
            {
                db.StatusShippings.Add(statusShipping);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(statusShipping);
        }

        // GET: StatusShippings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusShipping statusShipping = await db.StatusShippings.FindAsync(id);
            if (statusShipping == null)
            {
                return HttpNotFound();
            }
            return View(statusShipping);
        }

        // POST: StatusShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] StatusShipping statusShipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusShipping).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statusShipping);
        }

        // GET: StatusShippings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusShipping statusShipping = await db.StatusShippings.FindAsync(id);
            if (statusShipping == null)
            {
                return HttpNotFound();
            }
            return View(statusShipping);
        }

        // POST: StatusShippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StatusShipping statusShipping = await db.StatusShippings.FindAsync(id);
            db.StatusShippings.Remove(statusShipping);
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
