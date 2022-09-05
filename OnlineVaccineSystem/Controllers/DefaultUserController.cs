﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVaccineSystem.data;

namespace OnlineVaccineSystem.Controllers
{
    public class DefaultUserController : Controller
    {
        private VaccineSystemEntities2 db = new VaccineSystemEntities2();

        // GET: DefaultUser
        public ActionResult Index()
        {
            return View(db.UserMasters.ToList());
        }

        // GET: DefaultUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // GET: DefaultUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefaultUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MobileNo,Password,EmailId,Address,BirthDate,CreatedDate,ModifiedDate,IsAdmin,IsDeleted,UserId")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                if (userMaster.EmailId == null || userMaster.Name == null
                    || userMaster.MobileNo == null || userMaster.Address == null
                    || userMaster.Password == null || userMaster.BirthDate == null)
                {
                    ModelState.AddModelError("error", "Please Fill All Details");
                    return View(userMaster);
                }
                UserMaster user = db.UserMasters.FirstOrDefault(x => x.EmailId == userMaster.EmailId);
                if (user == null)
                {
                    userMaster.CreatedDate = DateTime.Now;
                    userMaster.ModifiedDate = DateTime.Now;
                    db.UserMasters.Add(userMaster);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ModelState.AddModelError("error", "User Already Exists");
                    return View(userMaster);
                }
            }

            return View(userMaster);
        }

        // GET: DefaultUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

      

        // POST: DefaultUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MobileNo,Password,EmailId,Address,BirthDate,CreatedDate,ModifiedDate,IsAdmin,IsDeleted,UserId")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                userMaster.ModifiedDate = DateTime.Now;
                db.Entry(userMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMaster);
        }

        // GET: DefaultUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: DefaultUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMaster userMaster = db.UserMasters.Find(id);
            db.UserMasters.Remove(userMaster);
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
