﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospitalproject.Data;
using Hospitalproject.Models;
using System.Diagnostics;

namespace Hospitalproject.Controllers
{
    public class VolunteerController : Controller
    {
        private HospitalContext db = new HospitalContext();
        // GET: Volunteer
        public ActionResult List()
        {
            return View();
        }

        // GET: Volunteer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Volunteer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteer/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: Volunteer/Edit/5
        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Volunteer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
