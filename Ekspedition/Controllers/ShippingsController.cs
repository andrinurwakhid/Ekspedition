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
using Ekspedition.ViewModel.Admin;

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
            
            var province = db.Provinces.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var regency = db.Regencies.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var district = db.Districts.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var village = db.Villages.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();

            var branch = db.Branchs.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var employee = db.Employees.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.FirstName+" "+i.LastName,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();


            var category = db.Categories.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var package = db.Packages.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            var status = db.StatusShippings.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();


            ViewBag.SProvinceList = province;
            ViewBag.SRegencyList = regency;
            ViewBag.SDistrictList = district;
            ViewBag.SVillageList = village;

            ViewBag.SBranchList = branch;
            ViewBag.SEmployeeList = employee;

            ViewBag.SCategoryList = category;
            ViewBag.SPackageList = package;
            ViewBag.SStatusList = status;
            return View();
        }

        // POST: Shippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdminVMShipping AdminVMShippings)
        {
            Shipping edit = new Shipping();
                if (ModelState.IsValid)
                {
                    edit.Employee_Id = 2;
                    edit.Quantity = AdminVMShippings.Quantity;
                    edit.Price = AdminVMShippings.Price;
                    edit.Weight = 40;
                    edit.TotalPrice = AdminVMShippings.TotalPrice;
                    if (AdminVMShippings.Assurances == "false")
                    {
                    edit.Assurances = false;
                    }
                        else
                    {
                    edit.Assurances = true;
                    }

                    edit.Date = DateTime.Now;

                    edit.SenderName = AdminVMShippings.SenderName;
                    edit.SenderPhone = AdminVMShippings.SenderPhone;
                    edit.SenderAddress = AdminVMShippings.SenderAddress;

                    edit.ReceiverName = AdminVMShippings.ReceiverName;
                    edit.ReceiverPhone = AdminVMShippings.ReceiverPhone;
                    edit.ReceiverAddress = AdminVMShippings.ReceiverAddress;
                    
                
                    var Dest = await db.Branchs.FindAsync(AdminVMShippings.Destination_Branch_Id);
                    var Cat = await db.Categories.FindAsync(AdminVMShippings.Category_Id);
                    var Stat = await db.StatusShippings.FindAsync(AdminVMShippings.StatusShipping_Id);
                    var Pack = await db.Packages.FindAsync(AdminVMShippings.Package_Id);

                    var SPId = await db.Provinces.FindAsync(AdminVMShippings.SenderProvince_Id);
                    var SRId = await db.Regencies.FindAsync(AdminVMShippings.SenderRegency_Id);
                    var SDId = await db.Districts.FindAsync(AdminVMShippings.SenderDistrict_Id);
                    var SVId = await db.Villages.FindAsync(AdminVMShippings.SenderVillage_Id);


                    var RPId = await db.Provinces.FindAsync(AdminVMShippings.ReceiverProvince_Id);
                    var RRId = await db.Regencies.FindAsync(AdminVMShippings.ReceiverRegency_Id);
                    var RDId = await db.Districts.FindAsync(AdminVMShippings.ReceiverDistrict_Id);
                    var RVId = await db.Villages.FindAsync(AdminVMShippings.ReceiverVillage_Id);

                    if (SPId != null && SRId != null && SDId != null && SVId != null && RPId != null && RRId != null && RDId != null && RVId != null && Cat != null && Stat != null && Pack != null && Dest != null)
                    {
                        edit.SenderProvince_Id = SPId.Id;
                        edit.SenderRegency_Id = SRId.Id;
                        edit.SenderDistrict_Id = SDId.Id;
                        edit.SenderVillage_Id = SVId.Id;

                        edit.ReceiverProvince_Id = RPId.Id;
                        edit.ReceiverRegency_Id = RRId.Id;
                        edit.ReceiverDistrict_Id = RDId.Id;
                        edit.ReceiverVillage_Id = RVId.Id;

                        edit.Category_Id = Cat.Id;
                        edit.StatusShipping_Id = Stat.Id;
                        edit.Package_Id = Pack.Id;
                        edit.Destination_Branch_Id = Dest.Id;
                    //db.Entry(editmajor).State = EntityState.Modified;
                    db.Shippings.Add(edit);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                            return RedirectToAction("Index");
                    }
            }
            return View();
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
