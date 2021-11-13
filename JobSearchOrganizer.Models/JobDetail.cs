using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class JobDetail
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string JobDescription { get; set; }
        public string HowApplied { get; set; }
        public string NextStep { get; set; }
        public DateTime DateApplied { get; set; }
        public string PotentialPointOfContact { get; set; }
        public DateTime DateOfLastContact { get; set; }
        public string InterviewNotes { get; set; }
        
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
