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
    public class PredbiljezbaController : Controller
    {
        private SeminarDbContext db = new SeminarDbContext();

        // GET: Predbiljezba
        [Authorize]
        public ActionResult Index()
        {
            var predbiljezba = db.Predbiljezba.Include(p => p.Seminar);
            return View(predbiljezba.ToList());
        }

        // GET: Predbiljezba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezba.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // GET: Predbiljezba/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminar.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            ViewBag.NazivSeminara = seminar.Naziv;

            Predbiljezba predbiljezba = new Predbiljezba();
            predbiljezba.IdSeminar = seminar.IdSeminar;

            return View(predbiljezba);
        }


        // POST: Predbiljezba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPredbiljezba,Datum,Ime,Prezime,Adresa,Email,Telefon,IdSeminar,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                predbiljezba.Datum = DateTime.Now;
                db.Predbiljezba.Add(predbiljezba);
                db.SaveChanges();
                return RedirectToAction("Search");
            }

            ViewBag.IdSeminar = new SelectList(db.Seminar, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // GET: Predbiljezba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezba.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeminar = new SelectList(db.Seminar, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // POST: Predbiljezba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPredbiljezba,Datum,Ime,Prezime,Adresa,Email,Telefon,IdSeminar,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predbiljezba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeminar = new SelectList(db.Seminar, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // GET: Predbiljezba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezba.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // POST: Predbiljezba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predbiljezba predbiljezba = db.Predbiljezba.Find(id);
            db.Predbiljezba.Remove(predbiljezba);
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
        public ActionResult Search(string searching)
        {
            bool shouldShowAllResults = searching == null;
            return View(db.Seminar
                .Where(x => x.Naziv.Contains(searching) || shouldShowAllResults)
                .Where(x => !x.Popunjen)
                .ToList());
        }

        [HttpPost]
        public ActionResult SearchFilter(string searching, string status)
        {
            bool shouldShowAllResults = searching == null;

            if (status == "Obrađeno")
            {

                return View("Index", db.Predbiljezba.Include(x => x.Seminar)
                    .Where(x => x.Status == true)
                    .Where(x => x.Seminar.Naziv.Contains(searching) || shouldShowAllResults)
                    .ToList());

            }
            else if (status == "Neobrađeno")
            {
                return View("Index", db.Predbiljezba.Include(x => x.Seminar)
                   .Where(x => x.Status == false)
                   .Where(x => x.Seminar.Naziv.Contains(searching) || shouldShowAllResults)
                   .ToList());
            }
            else
            {
                return View("Index", db.Predbiljezba.Include(x => x.Seminar)
                    .Where(x => x.Seminar.Naziv.Contains(searching) || shouldShowAllResults)
                    .ToList());
            }
        }

    }
}
