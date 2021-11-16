﻿using JobSearchOrganizer.Models.Enums;
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
        
        //[ForeignKey("Job")]//
        public int InterviewNoteId { get; set; }

        
        // [ForeignKey("ApplicationUser")] //
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        //Foreign Key??//
        [Required]
        [Display(Name = "Job Title Interviewed For")]
        public string JobTitleInterviewedFor { get; set; }
        // public virtual Job JobTitleInterviewedFor { get; set; } //

        //ForeignKey??//
        [Required]
        [Display(Name = "Company Interviewed For")]
        public string CompanyInterviewedFor { get; set; }
        // public virtual Company CompanyInterviewedFor { get; set; } //


        [Required]
        [Display(Name = "Person Interviewed With")]
        public string PersonInterviewedWith { get; set; }

        [Required]
        [Display(Name = "Method of Interview")]
        public MethodOfInterview MethodOfInterview { get; set; }
        
        [Display(Name = "Research Content to Prepare for Interview")]
        public string ResearchContenttoPrepare { get; set; }
        
        [Display(Name = "After Interview Notes")]
        public string AfterInterviewNotes { get; set; }
        
        [Display(Name = "Thank you note sent?")]
        public bool ThankyouNoteSent { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
