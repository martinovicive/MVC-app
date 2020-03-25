using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplikacija.Models;

namespace Aplikacija.Controllers
{
    public class ZaposlenikController : Controller
    {
        private SeminarDbContext db = new SeminarDbContext();

        // GET: Zaposlenik
        public ActionResult Index()
        {
            return View(db.Zaposlenik.ToList());
        }

        // GET: Zaposlenik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenik.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // GET: Zaposlenik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zaposlenik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdZaposlenik,Ime,Prezime,KorisnickoIme,Password")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db.Zaposlenik.Add(zaposlenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zaposlenik);
        }

        // GET: Zaposlenik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenik.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposlenik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdZaposlenik,Ime,Prezime,KorisnickoIme,Password")] Zaposlenik zaposlenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposlenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zaposlenik);
        }

        // GET: Zaposlenik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposlenik zaposlenik = db.Zaposlenik.Find(id);
            if (zaposlenik == null)
            {
                return HttpNotFound();
            }
            return View(zaposlenik);
        }

        // POST: Zaposlenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposlenik zaposlenik = db.Zaposlenik.Find(id);
            db.Zaposlenik.Remove(zaposlenik);
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
