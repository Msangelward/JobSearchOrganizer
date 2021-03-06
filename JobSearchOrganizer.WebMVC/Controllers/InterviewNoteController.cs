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
        //GET All Interview Notes
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new InterviewNoteService(userId);
            var model = service.GetInterviewNotes();
            
            return View(model);
        }

        // POST Interview Note
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterviewNoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateInterviewNoteService();

            if (service.CreateInterviewNote(model))
            {
                TempData["SaveResult"] = "Your Interview note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Interview Note could not be created.");

            return View(model);
        }

        //GET Interview Note by Id
        public ActionResult Details(int id)
        {
            var svc = CreateInterviewNoteService();
            var model = svc.GetInterviewNoteById(id);

            return View(model);
        }

        //GET Interview Note by Company
        [HttpGet]
        public ActionResult GetInterviewNoteByCompany(int companyId)
        {
            
            var service = CreateInterviewNoteService();
            var interviewNotes = service.GetInterviewNoteByCompany(companyId);

            return View(interviewNotes);
        }

        //UPDATE Interview Note
        public ActionResult Edit(int id)
        {
            var service = CreateInterviewNoteService();
            var detail = service.GetInterviewNoteById(id);
            var model =
                new InterviewNoteEdit
                {
                    InterviewNoteId = detail.InterviewNoteId,
                    JobTitleInterviewedFor = detail.JobTitleInterviewedFor,
                    CompanyInterviewedFor = detail.CompanyInterviewedFor,
                    PersonInterviewedWith = detail.PersonInterviewedWith,
                    MethodOfInterview = detail.MethodOfInterview,
                    ResearchContenttoPrepare = detail.ResearchContenttoPrepare,
                    AfterInterviewNotes = detail.AfterInterviewNotes,
                    ThankyouNoteSent = detail.ThankyouNoteSent,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InterviewNoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InterviewNoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInterviewNoteService();

            if (service.UpdateInterviewNote(model))
            {
                TempData["SaveResult"] = "Your Interview note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Interview note could not be updated.");
            return View(model);
        }

        //DELETE Interview Note
        public ActionResult Delete(int id)
        {
            var svc = CreateInterviewNoteService();
            var model = svc.GetInterviewNoteById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInterviewNoteService();

            service.DeleteInterviewNote(id);

            TempData["SaveResult"] = "Your Interview note was deleted.";

            return RedirectToAction("Index");
        }

        private InterviewNoteService CreateInterviewNoteService()
        {
            var userId = User.Identity.GetUserId();
            var service = new InterviewNoteService(userId);
            return service;
        }
    }
}