using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilterFunctionality.Models;

namespace FilterFunctionality.Controllers
{
    public class HomeController : Controller
    {
        private SampleDBContext db = new SampleDBContext();

        // GET: Home
        public ActionResult Index(string Search, string searchBy)
        {
            if (searchBy == "Name")
            {
                return View(db.Employee1.Where(x => x.Name.StartsWith(Search) || Search == null).ToList());
            }
            else
            {
                return View(db.Employee1.Where(x => x.Gender.Equals(Search) || Search == null).ToList());
            }
           
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Email")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Employee1.Add(employee1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee1);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Email")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee1);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee1 employee1 = db.Employee1.Find(id);
            if (employee1 == null)
            {
                return HttpNotFound();
            }
            return View(employee1);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee1 employee1 = db.Employee1.Find(id);
            db.Employee1.Remove(employee1);
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
