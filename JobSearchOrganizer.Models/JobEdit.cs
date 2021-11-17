using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }

        [Display (Name = "Title of Job Applied To")]
        public string JobTitle { get; set; }

        [Display (Name = "Company Applied To")]
        public string CompanyName { get; set; }

        [Display (Name = "Job Description")]
        public string JobDescription { get; set; }

        [Display (Name = "How You Applied")]
        public HowApplied HowApplied { get; set; }

        [Display (Name = "Your Next Step")]
        public string NextStep { get; set; }

        [Display (Name = "Date You Applied")]
        public DateTime DateApplied { get; set; }

        [Display (Name = "A Potential Point of Contact")]
        public string PotentialPointOfContact { get; set; }

        [Display (Name = "Date of Last Contact")]
        public DateTime DateOfLastContact { get; set; }

        [Display (Name = "Interview Notes")]
        public string InterviewNotes { get; set; }
        public bool IsStarred { get; set; }
    }
}
