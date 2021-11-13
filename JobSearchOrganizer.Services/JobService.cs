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
        private readonly Guid _userId;

        public JobService(Guid userId)
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
                                    JobTitle = e.Title,
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

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
