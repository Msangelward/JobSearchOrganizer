using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class Company
    {
        //[ForeignKey("Job")]//
        public int CompanyId { get; set; }

        
        //[ForeignKey("ApplicationUser")]//
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        //Foreign Key-many to many?//
        [Required]
        [Display (Name = "Company Name")]
        public string CompanyName { get; set; }

        public string JobTitle { get; set; }
        //public virtual Job JobTitle { get; set; }//

        [Required]
        [Display (Name = "Company Website")]
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
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
