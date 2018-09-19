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
    public class ShippingsController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: Shippings
        public async Task<ActionResult> Index()
        {
            var shippings = db.Shippings.Include(s => s.Category).Include(s => s.Employee).Include(s => s.Package).Include(s => s.StatusShipping).Include(s => s.Village).Include(s => s.Village1);
            return View(await shippings.ToListAsync());
        }

        // GET: Shippings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // GET: Shippings/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Name");
            ViewBag.Package_Id = new SelectList(db.Packages, "Id", "Name");
            ViewBag.StatusShippings_Id = new SelectList(db.StatusShippings, "Id", "Name");
            ViewBag.SenderVillage_Id = new SelectList(db.Villages, "Id", "District_Id");
            ViewBag.ReceiverVillage_Id = new SelectList(db.Villages, "Id", "District_Id");
            return View();
        }

        // POST: Shippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,Quantity,Assurances,Weight,Category_Id,SenderName,SenderPhone,SenderProvince_Id,SenderRegency_Id,SenderDistrict_Id,SenderVillage_Id,SenderAddress,ReceiverName,ReceiverPhone,ReceiverProvince_Id,ReceiverRegency_Id,ReceiverDistrict_Id,ReceiverVillage_Id,ReceiverAddress,Price,TotalPrice,StatusShippings_Id,Employee_Id,Package_Id,Destination_Branch_Id")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Shippings.Add(shipping);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", shipping.Category_Id);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Name", shipping.Employee_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Id", "Name", shipping.Package_Id);
            ViewBag.StatusShippings_Id = new SelectList(db.StatusShippings, "Id", "Name", shipping.StatusShipping_Id);
            ViewBag.SenderVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.SenderVillage_Id);
            ViewBag.ReceiverVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.ReceiverVillage_Id);
            return View(shipping);
        }

        // GET: Shippings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", shipping.Category_Id);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Name", shipping.Employee_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Id", "Name", shipping.Package_Id);
            ViewBag.StatusShippings_Id = new SelectList(db.StatusShippings, "Id", "Name", shipping.StatusShipping_Id);
            ViewBag.SenderVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.SenderVillage_Id);
            ViewBag.ReceiverVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.ReceiverVillage_Id);
            return View(shipping);
        }

        // POST: Shippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,Quantity,Assurances,Weight,Category_Id,SenderName,SenderPhone,SenderProvince_Id,SenderRegency_Id,SenderDistrict_Id,SenderVillage_Id,SenderAddress,ReceiverName,ReceiverPhone,ReceiverProvince_Id,ReceiverRegency_Id,ReceiverDistrict_Id,ReceiverVillage_Id,ReceiverAddress,Price,TotalPrice,StatusShippings_Id,Employee_Id,Package_Id,Destination_Branch_Id")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", shipping.Category_Id);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Name", shipping.Employee_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Id", "Name", shipping.Package_Id);
            ViewBag.StatusShippings_Id = new SelectList(db.StatusShippings, "Id", "Name", shipping.StatusShipping_Id);
            ViewBag.SenderVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.SenderVillage_Id);
            ViewBag.ReceiverVillage_Id = new SelectList(db.Villages, "Id", "District_Id", shipping.ReceiverVillage_Id);
            return View(shipping);
        }

        // GET: Shippings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: Shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shipping shipping = await db.Shippings.FindAsync(id);
            db.Shippings.Remove(shipping);
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
