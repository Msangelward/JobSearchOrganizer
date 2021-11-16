using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class InterviewNoteListItem
    {
        [Display (Name ="Interview Note Id")]
        public int InterviewNoteId { get; set; }
        
        [Display (Name ="Job Title Interviewed For")]
        public string JobTitleInterviewedFor { get; set; }

        [Display(Name = "Company Interviewed For")]
        public string CompanyInterviewedFor { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
