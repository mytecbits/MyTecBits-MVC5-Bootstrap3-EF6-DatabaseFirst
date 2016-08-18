using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTecBits_MVC5_Bootstrap3_EF6_DatabaseFirst.Models;

namespace MyTecBits_MVC5_Bootstrap3_EF6_DatabaseFirst.Controllers
{
    public class PeopleController : Controller
    {
        private WideWorldImportersEntities db = new WideWorldImportersEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Person1);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FullName,PreferredName,SearchName,IsPermittedToLogon,LogonName,IsExternalLogonProvider,HashedPassword,IsSystemUser,IsEmployee,IsSalesperson,UserPreferences,PhoneNumber,FaxNumber,EmailAddress,Photo,CustomFields,OtherLanguages,LastEditedBy,ValidFrom,ValidTo")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", person.LastEditedBy);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", person.LastEditedBy);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FullName,PreferredName,SearchName,IsPermittedToLogon,LogonName,IsExternalLogonProvider,HashedPassword,IsSystemUser,IsEmployee,IsSalesperson,UserPreferences,PhoneNumber,FaxNumber,EmailAddress,Photo,CustomFields,OtherLanguages,LastEditedBy,ValidFrom,ValidTo")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LastEditedBy = new SelectList(db.People, "PersonID", "FullName", person.LastEditedBy);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
