using JobSearchOrganizer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchOrganizer.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string JobDescription { get; set; }
        public HowApplied HowApplied { get; set; }
        public string NextStep { get; set; }
        public DateTime DateApplied { get; set; }
        public string PotentialPointOfContact { get; set; }
        public DateTime DateOfLastContact { get; set; }
        public string InterviewNotes { get; set; }

    }
}
