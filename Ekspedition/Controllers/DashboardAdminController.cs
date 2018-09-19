using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ekspedition.Controllers
{
    public class DashboardAdminController : Controller
    {
        // GET: DashboardAdmin
        private ExpeditionEntities db = new ExpeditionEntities();
        
        public ActionResult Index()
        {
            return View(db.HistoryShippings.ToList());
        }
        public ActionResult HistoryShippingList()
        {
            List<HistoryShipping> HSList = db.HistoryShippings.ToList();
            return View();
        }
        public ActionResult ShippingList()
        {
            List<Shipping> SList = db.Shippings.ToList();
            return View();
        }
        public ActionResult EmployeeList()
        {
            List<Employee> EList = db.Employees.ToList();
            return View();
        }
    }
}
