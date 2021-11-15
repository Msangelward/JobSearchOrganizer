using JobSearchOrganizer.Data;
using JobSearchOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Services
{
    public class InterviewNoteService
    {
        private readonly string _userId;

        public InterviewNoteService(string userId)
        {
            _userId = userId;
        }

        public bool CreateInterviewNote(InterviewNoteCreate model)
        {
            var entity =
                new InterviewNote()
                {
                    UserId = _userId,
                    JobTitleInterviewedFor = model.JobTitleInterviewedFor,
                    CompanyInterviewedFor = model.CompanyInterviewedFor,
                    PersonInterviewedWith = model.PersonInterviewedWith,
                    MethodOfInterview = model.MethodOfInterview,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.InterviewNotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InterviewNoteListItem> GetInterviewNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .InterviewNotes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new InterviewNoteListItem
                                {
                                    InterviewNoteId = e.InterviewNoteId,
                                    JobTitleInterviewedFor = e.JobTitleInterviewedFor,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public InterviewNoteDetail GetInterviewNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .InterviewNotes
                    .Single(e => e.InterviewNoteId == id && e.UserId == _userId);
                return
                    new InterviewNoteDetail
                    {
                        InterviewNoteId = entity.InterviewNoteId,
                        JobTitleInterviewedFor = entity.JobTitleInterviewedFor,
                        CompanyInterviewedFor = entity.CompanyInterviewedFor,
                        PersonInterviewedWith = entity.PersonInterviewedWith,
                        MethodOfInterview = entity.MethodOfInterview,
                        ResearchContenttoPrepare = entity.ResearchContenttoPrepare,
                        AfterInterviewNotes = entity.AfterInterviewNotes,
                        ThankyouNoteSent = entity.ThankyouNoteSent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateInterviewNote(InterviewNoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .InterviewNotes
                        .Single(e => e.InterviewNoteId == model.InterviewNoteId && e.UserId == _userId);

                entity.JobTitleInterviewedFor = model.JobTitleInterviewedFor;
                entity.CompanyInterviewedFor = model.CompanyInterviewedFor;
                entity.PersonInterviewedWith = model.PersonInterviewedWith;
                entity.MethodOfInterview = model.MethodOfInterview;
                entity.ResearchContenttoPrepare = model.ResearchContenttoPrepare;
                entity.AfterInterviewNotes = model.AfterInterviewNotes;
                entity.ThankyouNoteSent = model.ThankyouNoteSent;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
