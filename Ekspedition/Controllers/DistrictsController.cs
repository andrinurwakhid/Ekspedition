﻿using System;
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
    public class DistrictsController : Controller
    {
        private ExpeditionEntities db = new ExpeditionEntities();

        // GET: Districts
        public async Task<ActionResult> Index()
        {
            var districts = db.Districts.Include(d => d.Regency);
            return View(await districts.ToListAsync());
        }

        // GET: Districts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            ViewBag.Regency_Id = new SelectList(db.Regencies, "Id", "Province_Id");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Regency_Id,Name")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Regency_Id = new SelectList(db.Regencies, "Id", "Province_Id", district.Regency_Id);
            return View(district);
        }

        // GET: Districts/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.Regency_Id = new SelectList(db.Regencies, "Id", "Province_Id", district.Regency_Id);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Regency_Id,Name")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Regency_Id = new SelectList(db.Regencies, "Id", "Province_Id", district.Regency_Id);
            return View(district);
        }

        // GET: Districts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = await db.Districts.FindAsync(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            District district = await db.Districts.FindAsync(id);
            db.Districts.Remove(district);
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
