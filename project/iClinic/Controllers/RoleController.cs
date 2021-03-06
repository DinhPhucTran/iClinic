﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;
using iClinic.CustomFilters;
using System.Data.Entity;

namespace iClinic.Controllers
{
    [AuthLog(Roles = "1")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(IdentityUserRole role)
        {
            if (ModelState.IsValid)
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
            return View(role);
        }

    }
}