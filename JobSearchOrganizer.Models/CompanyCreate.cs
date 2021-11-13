using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class InterviewNoteCreate
    {  
        [Required]
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
    }
}
