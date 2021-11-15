using JobSearchOrganizer.Models.Enums;
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
        [Display(Name = "Job Title Interviewed For")]
        public string JobTitleInterviewedFor { get; set; }
        
        [Required]
        [Display(Name = "Company Interviewed For")]
        public string CompanyInterviewedFor { get; set; }
        
        [Required]
        [Display(Name = "Person Interviewed With")]
        public string PersonInterviewedWith { get; set; }
        
        [Required]
        [Display(Name = "Method of Interview")]
        public MethodOfInterview MethodOfInterview { get; set; }

    }
}
