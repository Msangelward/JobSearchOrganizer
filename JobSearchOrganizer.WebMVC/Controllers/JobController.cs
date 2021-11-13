using JobSearchOrganizer.Models;
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
            var model = new JobListItem[0];
            return View();
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (JobCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}