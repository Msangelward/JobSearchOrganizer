using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class CompanyDetail
    {
        public int CompanyId { get; set; }
        
        [Display (Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display (Name = "Company Website")]
        public string CompanyWebsite { get; set; }
        
        [Display (Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        
        [Display (Name = "Contact at Company")]
        public string ContactPerson { get; set; }
        
        [Display (Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display (Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
