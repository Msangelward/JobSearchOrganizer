using JobSearchOrganizer.Data;
using JobSearchOrganizer.Models;
using JobSearchOrganizer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobSearchOrganizer.WebMVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        // GET All Jobs
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            var model = service.GetJobs();

            return View(model);
        }

        //POST Job
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

        //GET Job by Id
        public ActionResult Details (int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        //GET Job by Title
        [HttpGet]
        public ActionResult GetJobsByJobTitle(string jobTitle)
        {
            var service = CreateJobService();
            var jobs = service.GetJobByTitle(jobTitle);

            return View(jobs);
        }

        //GET Job by ApplicationDate
        [HttpGet]
        public ActionResult GetJobByApplicationDate(DateTime dateApplied)
        {
            var service = CreateJobService();
            var jobs = service.GetJobByApplicationDate(dateApplied);

            return View(jobs);
        }

        //GET Job by Title
        [HttpGet]
        public ActionResult GetJobByLastDateContacted(DateTime lastDateContacted)
        {
            var service = CreateJobService();
            var jobs = service.GetJobByLastDateContacted(lastDateContacted);

            return View(jobs);
        }

        //UPDATE Job
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
            return View(model);
        }

        //DELETE Job
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