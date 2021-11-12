using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class InterviewNotes
    {
        [Key]
        public int InterviewNotesId { get; set; }
        [Required]
        public string JobInterviewedFor { get; set; }
        [Required]
        public string CompanyInterviewedFor { get; set; }
        [Required]
        public string PersonInterviewedWith { get; set; }
        [Required]
        public string MethodOfInterview { get; set; }
        public string ResearchContenttoPrepare { get; set; }
        public string AfterInterviewNotes { get; set; }
        public bool ThankyouNoteSent { get; set; }

    }
}
