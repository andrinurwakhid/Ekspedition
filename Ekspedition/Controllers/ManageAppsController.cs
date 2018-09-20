using Ekspedition.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.PCount = count;

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