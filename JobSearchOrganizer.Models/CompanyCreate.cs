using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class CompanyCreate
    {  
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Required]
        [Display(Name = "Company Name Website")]
        public string CompanyWebsite { get; set; }
    }
}
