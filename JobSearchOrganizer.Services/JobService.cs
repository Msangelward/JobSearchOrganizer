using JobSearchOrganizer.Data;
using JobSearchOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Services
{
    public class JobService
    {
        private readonly string _userId;

        public JobService(string userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    UserId = _userId,
                    JobTitle = model.JobTitle,
                    CompanyName = model.CompanyName,
                    JobDescription = model.JobDescription,
                    HowApplied = model.HowApplied,
                    NextStep = model.NextStep,
                    DateApplied = model.DateApplied,
                    PotentialPointOfContact = model.PotentialPointOfContact,
                    DateOfLastContact = model.DateOfLastContact,
                    InterviewNotes = model.InterviewNotes,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    JobTitle = e.JobTitle,
                                    DateApplied = e.DateApplied,
                                    DateOfLastContact = e.DateOfLastContact,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
            return query.ToArray();
            }
        }

        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == id && e.UserId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        JobTitle = entity.JobTitle,
                        CompanyName = entity.CompanyName,
                        JobDescription = entity.JobDescription,
                        HowApplied = entity.HowApplied,
                        NextStep = entity.NextStep,
                        DateApplied = entity.DateApplied,
                        PotentialPointOfContact = entity.PotentialPointOfContact,
                        DateOfLastContact = entity.DateOfLastContact,
                        InterviewNotes = entity.InterviewNotes,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }
        /*
        public IEnumerable<JobListItem> UserGetJobByTitle(string searchString)
        {

            var jobs = GetJobs();
            var jobItems = jobs.Where(c => c.JobTitle.Contains(searchString));

            return jobItems;
        }*/


        public IEnumerable<JobListItem> GetJobByTitle(string jobTitle)
        {
           using (var ctx = new ApplicationDbContext())
           {
                //var jobItems = jobTitle;//

                var query =
                    ctx
                        .Jobs
                        .Where(e => e.JobTitle == jobTitle && e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    JobTitle = e.JobTitle,
                                    DateApplied = e.DateApplied,
                                    DateOfLastContact = e.DateOfLastContact,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                    return query.ToArray();
           }
        }

        public IEnumerable<JobListItem> GetJobByApplicationDate(DateTime dateApplied)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var jobItems = jobTitle;//

                var query =
                    ctx
                        .Jobs
                        .Where(e => e.DateApplied == dateApplied && e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    JobTitle = e.JobTitle,
                                    DateApplied = e.DateApplied,
                                    DateOfLastContact = e.DateOfLastContact,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }

        }

        public IEnumerable<JobListItem> GetJobByLastDateContacted(DateTime lastDateContacted)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.DateOfLastContact == lastDateContacted && e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    JobTitle = e.JobTitle,
                                    DateApplied = e.DateApplied,
                                    DateOfLastContact = e.DateOfLastContact,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == model.JobId && e.UserId == _userId);

                entity.JobTitle = model.JobTitle;
                entity.CompanyName = model.CompanyName;
                entity.JobDescription = model.JobDescription;
                entity.HowApplied = model.HowApplied;
                entity.NextStep = model.NextStep;
                entity.DateApplied = model.DateApplied;
                entity.PotentialPointOfContact = model.PotentialPointOfContact;
                entity.DateOfLastContact = model.DateOfLastContact;
                entity.InterviewNotes = model.InterviewNotes;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob (int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == jobId && e.UserId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
