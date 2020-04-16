using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEnterprise_2.Models.ViewModel
{
    public class SubReport
    {
        public int Id { get; set; }

        public string Meeting { get; set; }

        public string Documents { get; set; }

        public string Comments { get; set; }

        public string TutorId { get; set; }

        public string StudentId { get; set; }
    }
}