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
        [Display(Name = "Job Title Interviewed For (Required)")]
        public string JobTitleInterviewedFor { get; set; }
        
        [Required]
        [Display(Name = "Company Interviewed For (Required)")]
        public string CompanyInterviewedFor { get; set; }
        
        [Required]
        [Display(Name = "Person Interviewed With (Required)")]
        public string PersonInterviewedWith { get; set; }

        [Required]
        [Display(Name = "Method of Interview (Required)")]
        public MethodOfInterview MethodOfInterview { get; set; }

        [Display(Name = "Research Content to Prepare for Interview")]
        public string ResearchContenttoPrepare { get; set; }

        [Display(Name = "After Interview Notes")]
        public string AfterInterviewNotes { get; set; }

        [Display(Name = "Thank you note sent?")]
        public bool ThankyouNoteSent { get; set; }
    }
}
