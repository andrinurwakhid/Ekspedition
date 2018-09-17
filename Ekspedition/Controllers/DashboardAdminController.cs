using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekspedition.Controllers
{
    public class DashboardAdminController : Controller
    {
        // GET: DashboardAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: DashboardAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
