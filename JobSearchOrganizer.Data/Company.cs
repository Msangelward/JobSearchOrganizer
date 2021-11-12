using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }

    }
}
