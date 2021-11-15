﻿using JobSearchOrganizer.Models;
using JobSearchOrganizer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchOrganizer.WebMVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new CompanyService(userId);
            var model = new CompanyListItem[0];

            return View();
        }

        // GET: Company
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity.GetUserId();
            var service = new CompanyService(userId);

            service.CreateCompany(model);

            return RedirectToAction("Index");
        }
    }
}