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
        public async Task<ActionResult> ListCategory()
        {
            return View(await db.Categories.ToListAsync());
        }
        public async Task<ActionResult> ListStatusShipping()
        {
            return View(await db.StatusShippings.ToListAsync());
        }
    }
}