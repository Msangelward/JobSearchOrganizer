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
        [Display (Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Required]
        [Display (Name = "Company Name Website")]
        public string CompanyWebsite { get; set; }
        
        [Display (Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [Display (Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display (Name = "Contact at Company")]
        public string ContactPerson { get; set; }
    }
}
