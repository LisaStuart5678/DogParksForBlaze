﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogParksForBlaze;

namespace DogParksForBlazeUI.Controllers
{
    public class DogParkDateAccountsController : Controller
    {
        private DogParkDateModel db = new DogParkDateModel();

        // GET: DogParkDateAccounts
        // the authorize function makes a user need to be logged in to see their info
        [Authorize]
        public ActionResult Index()
        {
            return View(db.DogParkDateAccounts.ToList());
        }

        // GET: DogParkDateAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DogParkDateAccount dogParkDateAccount = db.DogParkDateAccounts.Find(id);
            if (dogParkDateAccount == null)
            {
                return HttpNotFound();
            }
            return View(dogParkDateAccount);
        }

        // GET: DogParkDateAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogParkDateAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,UserName,EmailAddress,DogName,BarkBucks,TypeOfAccount,CreatedDate")] DogParkDateAccount dogParkDateAccount)
        {
            if (ModelState.IsValid)
            {
                db.DogParkDateAccounts.Add(dogParkDateAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dogParkDateAccount);
        }

        // GET: DogParkDateAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DogParkDateAccount dogParkDateAccount = db.DogParkDateAccounts.Find(id);
            if (dogParkDateAccount == null)
            {
                return HttpNotFound();
            }
            return View(dogParkDateAccount);
        }

        // POST: DogParkDateAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,UserName,EmailAddress,DogName,BarkBucks,TypeOfAccount,CreatedDate")] DogParkDateAccount dogParkDateAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dogParkDateAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dogParkDateAccount);
        }

        // GET: DogParkDateAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DogParkDateAccount dogParkDateAccount = db.DogParkDateAccounts.Find(id);
            if (dogParkDateAccount == null)
            {
                return HttpNotFound();
            }
            return View(dogParkDateAccount);
        }

        // POST: DogParkDateAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DogParkDateAccount dogParkDateAccount = db.DogParkDateAccounts.Find(id);
            db.DogParkDateAccounts.Remove(dogParkDateAccount);
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