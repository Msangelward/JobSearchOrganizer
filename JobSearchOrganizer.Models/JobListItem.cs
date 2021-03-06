using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class JobListItem
    {
        [Display (Name = "Job Id")]
        public int JobId { get; set; }

        [Display(Name = "Title of Job Applied To")]
        public int InterviewNoteId { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        [Display(Name = "Date You Applied")]
        public DateTime DateApplied { get; set; }

        [UIHint("Starred")]
        public bool IsStarred { get; set; }

        [Display(Name = "Date of Last Contact")]
        public DateTime DateOfLastContact { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
