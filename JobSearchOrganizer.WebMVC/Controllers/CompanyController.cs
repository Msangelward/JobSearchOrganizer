using JobSearchOrganizer.Models;
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
            if (!ModelState.IsValid) return View(model);

            var service = CreateCompanyService();

            if (service.CreateCompany(model))
            {
                TempData["SaveResult"] = "Your Company was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Company could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompanyService();
            var detail = service.GetCompanyById(id);
            var model =
                new CompanyEdit
                {
                    CompanyId = detail.CompanyId,
                    CompanyName = detail.CompanyName,
                    CompanyWebsite = detail.CompanyWebsite,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    Zip = detail.Zip,
                    PhoneNumber = detail.PhoneNumber,
                    ContactPerson = detail.ContactPerson,
        };
            return View(model);
        }

        private CompanyService CreateCompanyService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CompanyService(userId);
            return service;
        }
    }
}