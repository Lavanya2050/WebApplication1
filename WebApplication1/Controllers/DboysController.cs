using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DboysController : Controller
    {
        private NewsPaperSystemEntities1 db = new NewsPaperSystemEntities1();

        // GET: Dboys
        public ActionResult Index()
        {
            return View(db.Dboys.ToList());
        }

        // GET: Dboys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dboy dboy = db.Dboys.Find(id);
            if (dboy == null)
            {
                return HttpNotFound();
            }
            return View(dboy);
        }

        // GET: Dboys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dboys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "D_boyId,Newspaper,Location,Name,Mobile")] Dboy dboy)
        {
            if (ModelState.IsValid)
            {
                db.Dboys.Add(dboy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dboy);
        }

        // GET: Dboys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dboy dboy = db.Dboys.Find(id);
            if (dboy == null)
            {
                return HttpNotFound();
            }
            return View(dboy);
        }

        // POST: Dboys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "D_boyId,Newspaper,Location,Name,Mobile")] Dboy dboy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dboy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dboy);
        }

        // GET: Dboys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dboy dboy = db.Dboys.Find(id);
            if (dboy == null)
            {
                return HttpNotFound();
            }
            return View(dboy);
        }

        // POST: Dboys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dboy dboy = db.Dboys.Find(id);
            db.Dboys.Remove(dboy);
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
