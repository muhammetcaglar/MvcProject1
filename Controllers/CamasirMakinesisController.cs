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
    public class CamasirMakinesisController : Controller
    {
        private BeyazContext db = new BeyazContext();

        // GET: CamasirMakinesis
        public ActionResult Index()
        {
            var CamasirMakinesi = db.CamasirMakinesi.Include(c => c.Kategori);
            return View(CamasirMakinesi.ToList());
        }

        // GET: CamasirMakinesis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CamasirMakinesi camasirMakinesi = db.CamasirMakinesi.Find(id);
            if (camasirMakinesi == null)
            {
                return HttpNotFound();
            }
            return View(camasirMakinesi);
        }

        // GET: CamasirMakinesis/Create
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: CamasirMakinesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Renk,Boyutlar,KategoriId,Kg,ProgramSayisi")] CamasirMakinesi camasirMakinesi)
        {
            if (ModelState.IsValid)
            {
                db.CamasirMakinesi.Add(camasirMakinesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", camasirMakinesi.KategoriId);
            return View(camasirMakinesi);
        }

        // GET: CamasirMakinesis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CamasirMakinesi camasirMakinesi = db.CamasirMakinesi.Find(id);
            if (camasirMakinesi == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", camasirMakinesi.KategoriId);
            return View(camasirMakinesi);
        }

        // POST: CamasirMakinesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Renk,Boyutlar,KategoriId,Kg,ProgramSayisi")] CamasirMakinesi camasirMakinesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camasirMakinesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", camasirMakinesi.KategoriId);
            return View(camasirMakinesi);
        }

        // GET: CamasirMakinesis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CamasirMakinesi camasirMakinesi = db.CamasirMakinesi.Find(id);
            if (camasirMakinesi == null)
            {
                return HttpNotFound();
            }
            return View(camasirMakinesi);
        }

        // POST: CamasirMakinesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CamasirMakinesi camasirMakinesi = db.CamasirMakinesi.Find(id);
            db.CamasirMakinesi.Remove(camasirMakinesi);
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
