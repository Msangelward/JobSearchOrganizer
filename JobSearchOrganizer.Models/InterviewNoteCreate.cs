using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    class InterviewNoteCreate
    {
        [Required]
        public string JobTitleInterviewedFor { get; set; }
        [Required]
        public string CompanyInterviewedFor { get; set; }
        [Required]
        public string PersonInterviewedWith { get; set; }
        [Required]
        public MethodOfInterview MethodOfInterview { get; set; }

    }
}
