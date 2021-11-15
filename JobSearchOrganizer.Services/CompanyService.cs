using JobSearchOrganizer.Data;
using JobSearchOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Services
{
    public class CompanyService
    {
        private readonly string _userId;

        public CompanyService(string userId)
        {
            _userId = userId;
        }

        public bool CreateCompany(CompanyCreate model)
        {
            var entity =
                new Company()
                {
                    UserId = _userId,

                    CompanyName = model.CompanyName,
                    CompanyWebsite = model.CompanyWebsite,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Companies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompanyListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Companies
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CompanyListItem
                                {
                                    CompanyName = e.CompanyName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
