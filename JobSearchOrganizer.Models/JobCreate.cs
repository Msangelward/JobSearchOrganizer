using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class JobCreate
    {
        [Required]
        [Display (Name = "Title of Job Applied To (Required)")]
        public string JobTitle { get; set; }
        public int InterviewNoteId { get; set; }
        public int CompanyId { get; set; }

        [Display (Name = "Company Applied To")]
        public string CompanyName { get; set; }

        [Required]
        [Display (Name = "Job Description (Required)")]
        public string JobDescription { get; set; }

        [Required]
        [Display (Name = "How You Applied (Required)")]
        public HowApplied HowApplied { get; set; }

        [Display (Name = "Your Next Step")]
        public string NextStep { get; set; }

        [Required]
        [Display (Name = "Date You Applied (Required)")]
        public DateTime DateApplied { get; set; }

        [Display (Name = "A Potential Point of Contact")]
        public string PotentialPointOfContact { get; set; }

        [Display (Name = "Date of Last Contact (Required)")]
        public DateTime DateOfLastContact { get; set; }

        [Display (Name = "Interview Notes")]
        public string InterviewNotes { get; set; }

    }
}
