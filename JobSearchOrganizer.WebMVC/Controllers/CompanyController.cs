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
        // GET All Companies
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new CompanyService(userId);
            var model = service.GetCompanies();

            return View(model);
        }

        // POST Company
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

        //GET Company by Id
        public ActionResult Details(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        //UPDATE Company
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CompanyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCompanyService();

            if (service.UpdateCompany(model))
            {
                TempData["SaveResult"] = "Your Company was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Company could not be updated.");
            return View(model);
        }

        //DELETE Company
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCompanyService();

            service.DeleteCompany(id);

            TempData["SaveResult"] = "Your company was deleted.";

            return RedirectToAction("Index");
        }

        private CompanyService CreateCompanyService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CompanyService(userId);
            return service;
        }
    }
}