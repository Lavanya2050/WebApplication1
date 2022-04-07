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
    public class VendorListsController : Controller
    {
        private NewsPaperSystemEntities1 db = new NewsPaperSystemEntities1();

        // GET: VendorLists
        public ActionResult Index()
        {
            return View(db.VendorLists.ToList());
        }

        // GET: VendorLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorList vendorList = db.VendorLists.Find(id);
            if (vendorList == null)
            {
                return HttpNotFound();
            }
            return View(vendorList);
        }

        // GET: VendorLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorID,VName,NewsPaper,Mobile,NewspaperID")] VendorList vendorList)
        {
            if (ModelState.IsValid)
            {
                db.VendorLists.Add(vendorList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendorList);
        }

        // GET: VendorLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorList vendorList = db.VendorLists.Find(id);
            if (vendorList == null)
            {
                return HttpNotFound();
            }
            return View(vendorList);
        }

        // POST: VendorLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VName,NewsPaper,Mobile,NewspaperID")] VendorList vendorList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendorList);
        }

        // GET: VendorLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorList vendorList = db.VendorLists.Find(id);
            if (vendorList == null)
            {
                return HttpNotFound();
            }
            return View(vendorList);
        }

        // POST: VendorLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorList vendorList = db.VendorLists.Find(id);
            db.VendorLists.Remove(vendorList);
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
