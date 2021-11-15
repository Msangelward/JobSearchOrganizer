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
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            var model = service.GetJobs();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            if (service.CreateJob(model));
            {
                TempData["SaveResult"] = "Your job was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job could not be created.");

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    JobId = detail.JobId,
                    JobTitle = detail.JobTitle,
                    CompanyName = detail.CompanyName,
                    JobDescription = detail.JobDescription,
                    HowApplied = detail.HowApplied,
                    NextStep = detail.NextStep,
                    DateApplied = detail.DateApplied,
                    PotentialPointOfContact = detail.PotentialPointOfContact,
                    DateOfLastContact = detail.DateOfLastContact,
                    InterviewNotes = detail.InterviewNotes
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JobId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateJobService();

            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Your job was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your job could not be updated.");
            return View();
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();

            service.DeleteJob(id);

            TempData["SaveResult"] = "Your job was deleted.";

            return RedirectToAction("Index");
        }

        private JobService CreateJobService()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            return service;
        }
    }
}