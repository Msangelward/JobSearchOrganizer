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
        
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
