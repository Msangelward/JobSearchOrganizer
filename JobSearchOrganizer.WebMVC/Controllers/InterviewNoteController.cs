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
    public class InterviewNoteController : Controller
    {
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new InterviewNoteService(userId);
            var model = new InterviewNoteListItem[0];
            
            return View();
        }

        // GET: InterviewNote
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterviewNoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIntervewNoteService();

            if (service.CreateInterviewNote(model))
            {
                TempData["SaveResult"] = "Your Interview note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Interview Note could not be created.");

            return View(model);
        }

        private InterviewNoteService CreateIntervewNoteService()
        {
            var userId = User.Identity.GetUserId();
            var service = new InterviewNoteService(userId);
            return service;
        }
    }
}