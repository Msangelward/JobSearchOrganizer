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
        [Display(Name = "Title of Job Applied To")]
        public string JobTitle { get; set; }

        [Display(Name = "Company Applied To")]
        public string CompanyName { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        
    }
}
