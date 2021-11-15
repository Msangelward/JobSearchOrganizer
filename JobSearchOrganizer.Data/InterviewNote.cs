using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Data
{
    public class InterviewNote
    {
        [Key]
        public int InterviewNoteId { get; set; }

        
        // [ForeignKey("ApplicationUser")] //
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        

        [Required]
        public string JobTitleInterviewedFor { get; set; }
        [Required]
        public string CompanyInterviewedFor { get; set; }
        [Required]
        public string PersonInterviewedWith { get; set; }
        [Required]
        public MethodOfInterview MethodOfInterview { get; set; }
        public string ResearchContenttoPrepare { get; set; }
        public string AfterInterviewNotes { get; set; }
        public bool ThankyouNoteSent { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
