using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public Enum HowApplied { get; set; }
        public string NextStep { get; set; }
        [Required]
        public DateTime DateApplied { get; set; }
        public string PotentialPointOfContact { get; set; }
        public DateTime DateOfLastContact { get; set; }
        public string InterviewNotes { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
