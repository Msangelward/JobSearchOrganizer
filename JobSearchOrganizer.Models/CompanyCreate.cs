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
        public string CompanyName { get; set; }
        [Required]
        public string CompanyWebsite { get; set; }
    }
}
