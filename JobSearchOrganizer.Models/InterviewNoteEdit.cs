using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class InterviewNoteEdit
    {
        public int InterviewNoteId { get; set; }

        [Display(Name = "Job Title Interviewed For")]
        public string JobTitleInterviewedFor { get; set; }

        [Display(Name = "Company Interviewed For")]
        public string CompanyInterviewedFor { get; set; }

        [Display(Name = "Person Interviewed With")]
        public string PersonInterviewedWith { get; set; }

        [Display(Name = "Method of Interview")]
        public MethodOfInterview MethodOfInterview { get; set; }

        [Display(Name = "Research Content to Prepare for Interview")]
        public string ResearchContenttoPrepare { get; set; }

        [Display(Name = "After Interview Notes")]
        public string AfterInterviewNotes { get; set; }

        [Display(Name = "Thank you note sent?")]
        public bool ThankyouNoteSent { get; set; }
    }
}
