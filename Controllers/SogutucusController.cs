using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyazEsyaProje.Models;

namespace BeyazEsyaProje.Controllers
{
    public class SogutucusController : Controller
    {
        private BeyazContext db = new BeyazContext();

        // GET: Sogutucus
        public ActionResult Index()
        {
            var Sgotucu = db.Sgotucu.Include(s => s.Kategori);
            return View(Sgotucu.ToList());
        }

        // GET: Sogutucus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sgotucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            return View(sogutucu);
        }

        // GET: Sogutucus/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Sogutucus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Renk,Boyutlar,KategoriId,SogutucuTip,Hacim")] Sogutucu sogutucu)
        {
            if (ModelState.IsValid)
            {
                db.Sgotucu.Add(sogutucu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", sogutucu.KategoriId);
            return View(sogutucu);
        }

        // GET: Sogutucus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sgotucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", sogutucu.KategoriId);
            return View(sogutucu);
        }

        // POST: Sogutucus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Renk,Boyutlar,KategoriId,SogutucuTip,Hacim")] Sogutucu sogutucu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sogutucu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", sogutucu.KategoriId);
            return View(sogutucu);
        }

        // GET: Sogutucus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sgotucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            return View(sogutucu);
        }

        // POST: Sogutucus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sogutucu sogutucu = db.Sgotucu.Find(id);
            db.Sgotucu.Remove(sogutucu);
            db.SaveChanges();
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
