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
                                    CompanyId = e.CompanyId,
                                    CompanyName = e.CompanyName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public CompanyDetail GetCompanyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == id && e.UserId == _userId);
                return
                    new CompanyDetail
                    {
                        CompanyId = entity.CompanyId,
                        CompanyName = entity.CompanyName,
                        CompanyWebsite = entity.CompanyWebsite,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        PhoneNumber = entity.PhoneNumber,
                        ContactPerson = entity.ContactPerson,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public void AddInterviewNotesToCompanies(int interviewNoteId, int companyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundInterviewNote = ctx.InterviewNotes.Single(c => c.InterviewNoteId == interviewNoteId);
                var foundCompany = ctx.Companies.Single(s => s.CompanyId == companyId);
                foundCompany.ListOfInterviewNotes.Add(foundInterviewNote);
                var testing = ctx.SaveChanges();
            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == model.CompanyId && e.UserId == _userId);

                entity.CompanyName = model.CompanyName;
                entity.CompanyWebsite = model.CompanyWebsite;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.PhoneNumber = model.PhoneNumber;
                entity.ContactPerson = model.ContactPerson;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompany(int companyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == companyId && e.UserId == _userId);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
