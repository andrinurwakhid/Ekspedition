using Ekspedition.ViewModel;
using Ekspedition.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Ekspedition.Controllers
{
    public class ManageAppsController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();
        // GET: ManageApps

        public List<Shipping> GetShippingList()
        {
            List<Shipping> SList = new List<Shipping>();

            //count
            var query = db.Shippings.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.SCount = count;

            return SList;
        }

        private List<HistoryShipping> GetHistoryShippingList()
        {
            List<HistoryShipping> HSList = new List<HistoryShipping>();
            ManageApps DA = new ManageApps();

            //count
            var query = db.HistoryShippings.Where(x => x.Shipping.Id.Equals(x.Shipping_Id)).ToList();
            var query2 = from hs in db.HistoryShippings
                         from s in db.Shippings
                         from ss in db.StatusShippings

                         from e in db.Employees

                         from b in db.Branchs
                         from w in db.Warehouses


                         from pa in db.Packages
                         from c in db.Categories
                         select new { hs, s, ss, e, b, w, pa, c };
            var query2list = query2.ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.HSCount = count;
            return HSList;
        }

        private List<Category> GetCategoryList()
        {
            List<Category> CList = new List<Category>();

            //count
            var query = db.Categories.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.CCount = count;

            return CList;
        }
        private List<Package> GetPackageList()
        {
            List<Package> PList = new List<Package>();

            //count
            var query = db.Packages.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.PCount = count;

            return PList;
        }
        private List<StatusShipping> GetStatusShippingList()
        {
            List<StatusShipping> SSList = new List<StatusShipping>();

            //count
            var query = db.StatusShippings.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.SSCount = count;

            return SSList;
        }
        private List<Employee> GetEmployeeList()
        {
            List<Employee> EList = new List<Employee>();

            //count
            var query = db.Employees.Where(x => x.Id.Equals(1)).ToList();
            int count = 0, id = 0;
            string fname = "", lname = "", position = "", username = "", password = "", branch = "";
            foreach (var sid in query)
            {
                count = count + 1;

                id = sid.Id;
                fname = sid.FirstName;
                lname = sid.LastName;
                position = sid.Position;
                username = sid.Username;
                password = sid.Password;
                branch = sid.Branch.Name;
            }
            ViewBag.ECount = count;

            ViewBag.EId = id;
            ViewBag.EFName = fname;
            ViewBag.ELName = lname;
            ViewBag.EBranch = branch;
            ViewBag.EPosition = position;
            ViewBag.EUsername = username;
            ViewBag.EPassword = password;
            return EList;
        }
        private List<Warehouse> GetWarehouseList()
        {
            List<Warehouse> WList = new List<Warehouse>();

            //count
            var query = db.Warehouses.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }

            var List = db.Warehouses.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();

            ViewBag.EWarehouseList = List;
            ViewBag.WCount = count;

            return WList;
        }
        private List<Branch> GetBranchList()
        {
            List<Branch> BList = new List<Branch>();

            //count
            var query = db.Branchs.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }

            var ListBranch = db.Branchs.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();

            ViewBag.BCount = count;
            ViewBag.EBranchList = ListBranch;
            return BList;
        }
        private List<Province> GetProvinceList()
        {
            List<Province> PList = new List<Province>();

            //count
            var query = db.Provinces.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            
            var province = db.Provinces.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArray();
            
            ViewBag.PCount = count;
            ViewBag.ProvList = province;

            return PList;
        }
        private List<Regency> GetRegencyList()
        {
            List<Regency> RList = new List<Regency>();

            //count
            var query = db.Regencies.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.RCount = count;

            return RList;
        }
        public JsonResult RegencyList(int dataId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Regency> RegList = db.Regencies.Where(x => x.Provinces_Id == dataId.ToString()).ToList();
            return Json(RegList, JsonRequestBehavior.AllowGet);
        }

        private List<District> GetDistrictList()
        {
            List<District> DList = new List<District>();

            //count
            var query = db.Districts.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.DCount = count;

            return DList;
        }
        public JsonResult DistrictList(int dataId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<District> DistList = db.Districts.Where(x => x.Regencys_Id == dataId.ToString()).ToList();
            return Json(DistList, JsonRequestBehavior.AllowGet);
        }

        private List<Village> GetVillageList()
        {
            List<Village> VList = new List<Village>();

            //count
            var query = db.Villages.Select(c => c.Id).ToList();
            int count = 0;
            foreach (var sid in query)
            {
                count = count + 1;
            }
            ViewBag.VCount = count;

            return VList;
        }
        public JsonResult VillageList(int dataId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Village> VillList = db.Villages.Where(x => x.Districts_Id == dataId.ToString()).ToList();
            return Json(VillList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditCategory2(AdminVMCategory AdminVMCategorys)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                var edit = db.Categories.Where(x => x.Id.Equals(AdminVMCategorys.Id)).SingleOrDefault();
                edit.Name = AdminVMCategorys.Name;
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                status = true;
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult AddCategory(Category Categorys)
        {
            bool status = false;
            try
            {
                db.Categories.Add(Categorys);
                db.SaveChanges();
                TempData["message"] = "Add Data Success";
                status = true;
            }
            catch
            {
                TempData["message"] = "Error";
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }

        [HttpPost]
        public JsonResult AddStatus(StatusShipping datatable)
        {
            bool status = false;
            try
            {
                db.StatusShippings.Add(datatable);
                db.SaveChanges();
                TempData["message"] = "Add Data Success";
                status = true;
            }
            catch
            {
                TempData["message"] = "Error";
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }

        [HttpPost]
        public JsonResult AddPackage(Package datatable)
        {
            bool status = false;
            try
            {
                db.Packages.Add(datatable);
                db.SaveChanges();
                TempData["message"] = "Add Data Success";
                status = true;
            }
            catch
            {
                TempData["message"] = "Error";
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }


        [HttpPost]
        public JsonResult AddBranch(Branch datatable)
        {
            bool status = false;
            try
            {
                db.Branchs.Add(datatable);
                db.SaveChanges();
                status = true;
            }
            catch
            {
                TempData["message"] = "Error";
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }

        [HttpPost]
        public JsonResult AddWarehouse(Warehouse datatable)
        {
            bool status = false;
            try
            {
                db.Warehouses.Add(datatable);
                db.SaveChanges();
                TempData["message"] = "Add Data Success";
                status = true;
            }
            catch
            {
                TempData["message"] = "Error";
            }
            return new JsonResult
            {
                Data = new
                {
                    status = status,
                    Url = ""
                }
            };
        }

        public async Task<ActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category data = await db.Categories.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCategory([Bind(Include = "Id,Name")] Category Categorys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Categorys).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["message"] = "Edit Data Success";
                return RedirectToAction("Index");
            }
            return View(Categorys);
        }

        public async Task<ActionResult> EditPackage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package data = await db.Packages.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPackage([Bind(Include = "Id,Name,Price")] Package Packages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Packages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["message"] = "Edit Data Success";
                return RedirectToAction("Index");
            }
            return View(Packages);
        }


        public async Task<ActionResult> EditStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusShipping data = await db.StatusShippings.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStatus([Bind(Include = "Id,Name")] StatusShipping StatusShippings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(StatusShippings).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["message"] = "Edit Data Success";
                return RedirectToAction("Index");
            }
            return View(StatusShippings);
        }

        public async Task<ActionResult> EditBranch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch data = await db.Branchs.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }

            var warehouse = await db.Warehouses.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in warehouse)
            {
                if (get.Value == data.Warehouse.Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var province = await db.Provinces.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in province)
            {
                if (get.Value == data.Province_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var regency = await db.Regencies.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in regency)
            {
                if (get.Value == data.Regency_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var village = await db.Villages.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in village)
            {
                if (get.Value == data.Village_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var district = await db.Districts.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in district)
            {
                if (get.Value == data.District_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            ViewBag.BWarehouseListEdit = warehouse;
            ViewBag.BProvinceListEdit = province;
            ViewBag.BRegencyListEdit = regency;
            ViewBag.BDistrictListEdit = district;
            ViewBag.BVillageListEdit = village;
            return View(data);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBranch([Bind(Include = "Id,Name,Province_Id,Regency_Id,District_Id,Village_Id,Address,Warehouse_Id,Price")] Branch Branchs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Branchs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["message"] = "Edit Data Success";
                return RedirectToAction("Index");
            }
            return View(Branchs);
        }

        public async Task<ActionResult> EditWarehouse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse data = await db.Warehouses.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }


            var province = await db.Provinces.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in province)
            {
                if (get.Value == data.Province_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var regency = await db.Regencies.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in regency)
            {
                if (get.Value == data.Regency_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var village = await db.Villages.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in village)
            {
                if (get.Value == data.Village_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }

            var district = await db.Districts.OrderBy(x => x.Id).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = false
            }).ToArrayAsync();

            foreach (var get in district)
            {
                if (get.Value == data.District_Id.ToString())
                {
                    get.Selected = true;
                    break;
                }
            }
            
            ViewBag.WProvinceListEdit = province;
            ViewBag.WRegencyListEdit = regency;
            ViewBag.WDistrictListEdit = district;
            ViewBag.WVillageListEdit = village;
            return View(data);
        }

        // POST: HistoryShippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditWarehouse([Bind(Include = "Id,Name,Province_Id,Regency_Id,District_Id,Village_Id,Address")] Warehouse Warehouses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Warehouses).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["message"] = "Edit Data Success";
                return RedirectToAction("Index");
            }
            return View(Warehouses);
        }



        public async Task<ActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category data = await db.Categories.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                Category data = await db.Categories.FindAsync(id);
                db.Categories.Remove(data);
                await db.SaveChangesAsync();
                TempData["message"] = "Delete Data Success";
            }
            catch
            {
                TempData["message"] = "Category have a relation";
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusShipping data = await db.StatusShippings.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("DeleteStatus")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            try
            {
                StatusShipping data = await db.StatusShippings.FindAsync(id);
                db.StatusShippings.Remove(data);
                await db.SaveChangesAsync();
                TempData["message"] = "Delete Data Success";
            }
            catch
            {
                TempData["message"] = "StatusShippings have a relation";
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteBranch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch data = await db.Branchs.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("DeleteBranch")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBranch(int id)
        {
            try
            {
                Branch data = await db.Branchs.FindAsync(id);
                db.Branchs.Remove(data);
                await db.SaveChangesAsync();
                TempData["message"] = "Delete Data Success";
            }
            catch
            {
                TempData["message"] = "Branchs have a relation";
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteWarehouse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse data = await db.Warehouses.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("DeleteWarehouse")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteWarehouse(int id)
        {
            try
            {
                Warehouse data = await db.Warehouses.FindAsync(id);
                db.Warehouses.Remove(data);
                await db.SaveChangesAsync();
                TempData["message"] = "Delete Data Success";
            }
            catch
            {
                TempData["message"] = "Warehouses have a relation";
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeletePackage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package data = await db.Packages.FindAsync(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("DeletePackage")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePackage(int id)
        {
            try
            {
                Package data = await db.Packages.FindAsync(id);
                db.Packages.Remove(data);
                await db.SaveChangesAsync();
                TempData["message"] = "Delete Data Success";
            }
            catch
            {
                TempData["message"] = "Packages have a relation";
            }
            return RedirectToAction("Index");
        }













        public ActionResult Index()
        {
            ManageApps mymodel = new ManageApps();

            mymodel.VMProvince = GetProvinceList();
            mymodel.VMRegency = GetRegencyList();
            mymodel.VMDistrict = GetDistrictList();
            mymodel.VMVillage = GetVillageList();

            mymodel.VMShipping = GetShippingList();
            mymodel.VMHistoryShipping = GetHistoryShippingList();

            mymodel.VMCategory = GetCategoryList();
            mymodel.VMPackage = GetPackageList();
            mymodel.VMStatusShipping = GetStatusShippingList();

            mymodel.VMEmployee = GetEmployeeList();

            mymodel.VMWarehouse = GetWarehouseList();
            mymodel.VMBranch = GetBranchList();

            return View(mymodel);
        }
    }
}