using JobSearchOrganizer.Models;
using JobSearchOrganizer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobSearchOrganizer.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Job")]
    public class JobController : ApiController
    {
        private bool SetStarState(int jobId, bool newState)
        {
            // Create the service
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);

            // Get the job
            var detail = service.GetJobById(jobId);

            // Create the JobEdit model instance with the new star state
            var updateJob =
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

            // Return a value indicating whether the update succeeded
            return service.UpdateJob(updateJob);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
