using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        //[ForeignKey("ApplicationUser")]//
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Job Title Applied To")]
        public string JobTitle { get; set; }
        [Display(Name = "Company Applied To")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Required]
        [Display(Name = "How You Applied")]
        public string HowApplied { get; set; }
        [Display(Name = "Your Next Step")]
        public string NextStep { get; set; }
        [Required]
        [Display(Name = "Date You Applied")]
        public DateTime DateApplied { get; set; }
        [Display(Name = "A Potential Point of Contact")]
        public string PotentialPointOfContact { get; set; }
        [Display(Name = "Date of Last Contact")]
        public DateTime DateOfLastContact { get; set; }
        [Display(Name = "Interview Notes")]
        public string InterviewNotes { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
