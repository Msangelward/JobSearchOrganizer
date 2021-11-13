using JobSearchOrganizer.Models;
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
        // GET: InterviewNote
        public ActionResult Index()
        {
            var model = new InterviewNoteListItem[0];
            return View();
        }
    }
}