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
    public class HistoryShippingsController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: HistoryShippings
        public async Task<ActionResult> Index()
        {
            var historyShippings = db.HistoryShippings;
            return View(await historyShippings.ToListAsync());
        }

        // GET: HistoryShippings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryShipping historyShipping = await db.HistoryShippings.FindAsync(id);
            if (historyShipping == null)
            {
                return HttpNotFound();
            }
            return View(historyShipping);
        }

        // GET: HistoryShippings/Create
        public ActionResult Create()
        {
            ViewBag.Shipping_Id = new SelectList(db.Shippings, "Id", "SenderName");
            return View();
        }

        // POST: HistoryShippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Shipping_Id,Employee_Id,StatusShipping_Id")] HistoryShipping historyShipping)
        {
            if (ModelState.IsValid)
            {
                db.HistoryShippings.Add(historyShipping);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Shipping_Id = new SelectList(db.Shippings, "Id", "SenderName", historyShipping.Shipping_Id);
            return View(historyShipping);
        }

        // GET: HistoryShippings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryShipping historyShipping = await db.HistoryShippings.FindAsync(id);
            if (historyShipping == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shipping_Id = new SelectList(db.Shippings, "Id", "SenderName", historyShipping.Shipping_Id);
            return View(historyShipping);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Shipping_Id,Employee_Id,StatusShipping_Id")] HistoryShipping historyShipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyShipping).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Shipping_Id = new SelectList(db.Shippings, "Id", "SenderName", historyShipping.Shipping_Id);
            return View(historyShipping);
        }

        // GET: HistoryShippings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryShipping historyShipping = await db.HistoryShippings.FindAsync(id);
            if (historyShipping == null)
            {
                return HttpNotFound();
            }
            return View(historyShipping);
        }

        // POST: HistoryShippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HistoryShipping historyShipping = await db.HistoryShippings.FindAsync(id);
            db.HistoryShippings.Remove(historyShipping);
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
