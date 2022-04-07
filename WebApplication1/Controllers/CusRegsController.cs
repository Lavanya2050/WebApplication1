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
    public class CusRegsController : Controller
    {
        private NewsPaperSystemEntities1 db = new NewsPaperSystemEntities1();

        // GET: CusRegs
        public ActionResult Index()
        {
            return View(db.CusRegs.ToList());
        }

        // GET: CusRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CusReg cusReg = db.CusRegs.Find(id);
            if (cusReg == null)
            {
                return HttpNotFound();
            }
            return View(cusReg);
        }

        // GET: CusRegs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CusRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,CustomerName,CustomerID,Email,Location,MobileNO,Newspaper")] CusReg cusReg)
        {
            if (ModelState.IsValid)
            {
                db.CusRegs.Add(cusReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cusReg);
        }

        // GET: CusRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CusReg cusReg = db.CusRegs.Find(id);
            if (cusReg == null)
            {
                return HttpNotFound();
            }
            return View(cusReg);
        }

        // POST: CusRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,CustomerName,CustomerID,Email,Location,MobileNO,Newspaper")] CusReg cusReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cusReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cusReg);
        }

        // GET: CusRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CusReg cusReg = db.CusRegs.Find(id);
            if (cusReg == null)
            {
                return HttpNotFound();
            }
            return View(cusReg);
        }

        // POST: CusRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CusReg cusReg = db.CusRegs.Find(id);
            db.CusRegs.Remove(cusReg);
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
