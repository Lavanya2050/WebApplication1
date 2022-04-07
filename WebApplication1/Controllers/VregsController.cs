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
    public class VregsController : Controller
    {
        private NewsPaperSystemEntities1 db = new NewsPaperSystemEntities1();

        // GET: Vregs
        public ActionResult Index()
        {
            return View(db.Vregs.ToList());
        }

        // GET: Vregs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vreg vreg = db.Vregs.Find(id);
            if (vreg == null)
            {
                return HttpNotFound();
            }
            return View(vreg);
        }

        // GET: Vregs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vregs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UesID,VendorName,VendorID,Newspaper,Cost_Per_Month")] Vreg vreg)
        {
            if (ModelState.IsValid)
            {
                db.Vregs.Add(vreg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vreg);
        }

        // GET: Vregs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vreg vreg = db.Vregs.Find(id);
            if (vreg == null)
            {
                return HttpNotFound();
            }
            return View(vreg);
        }

        // POST: Vregs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UesID,VendorName,VendorID,Newspaper,Cost_Per_Month")] Vreg vreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vreg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vreg);
        }

        // GET: Vregs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vreg vreg = db.Vregs.Find(id);
            if (vreg == null)
            {
                return HttpNotFound();
            }
            return View(vreg);
        }

        // POST: Vregs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vreg vreg = db.Vregs.Find(id);
            db.Vregs.Remove(vreg);
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
