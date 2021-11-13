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
    }
}
