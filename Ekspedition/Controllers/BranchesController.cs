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
    public class BranchesController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: Branches
        public async Task<ActionResult> Index()
        {
            var branchs = db.Branchs.Include(b => b.Village).Include(b => b.Warehouse);
            return View(await branchs.ToListAsync());
        }

        // GET: Branches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branchs.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            ViewBag.Village_Id = new SelectList(db.Villages, "Id", "District_Id");
            ViewBag.Warehouse_Id = new SelectList(db.Warehouses, "Id", "Name");
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Province_Id,Regency_Id,District_Id,Village_Id,Address,Warehouse_Id,Price")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branchs.Add(branch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Village_Id = new SelectList(db.Villages, "Id", "District_Id", branch.Village_Id);
            ViewBag.Warehouse_Id = new SelectList(db.Warehouses, "Id", "Name", branch.Warehouse_Id);
            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branchs.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.Village_Id = new SelectList(db.Villages, "Id", "District_Id", branch.Village_Id);
            ViewBag.Warehouse_Id = new SelectList(db.Warehouses, "Id", "Name", branch.Warehouse_Id);
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Province_Id,Regency_Id,District_Id,Village_Id,Address,Warehouse_Id,Price")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Village_Id = new SelectList(db.Villages, "Id", "District_Id", branch.Village_Id);
            ViewBag.Warehouse_Id = new SelectList(db.Warehouses, "Id", "Name", branch.Warehouse_Id);
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await db.Branchs.FindAsync(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Branch branch = await db.Branchs.FindAsync(id);
            db.Branchs.Remove(branch);
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
