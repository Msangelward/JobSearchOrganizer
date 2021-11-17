using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [ForeignKey("InterviewNote")]
        public int InterviewNoteId { get; set; }
        public virtual InterviewNote InterviewNote { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display (Name = "Title of Job Applied To")]
        public string JobTitle { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [Display (Name = "Company Applied To")]
        public virtual Company Company { get; set; }//

        [Required]
        [Display (Name = "Job Description")]
        public string JobDescription { get; set; }
        
        [Required]
        [Display (Name = "How You Applied")]
        public HowApplied HowApplied { get; set; }
        
        [Display (Name = "Your Next Step")]
        public string NextStep { get; set; }
        
        [Required]
        [Display (Name = "Date You Applied")]
        public DateTime DateApplied { get; set; }
        
        [Display (Name = "A Potential Point of Contact")]
        public string PotentialPointOfContact { get; set; }
        
        [Display (Name = "Date of Last Contact")]
        public DateTime DateOfLastContact { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
