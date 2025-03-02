﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RezhDumaASPCore_Backend.Model
{
    public class Application : Message
    {
        public List<DistrictApplication> DistrictApplications { get; set; }
        public List<District> Districts { get; set; }

        public List<CategoryApplication> CategoryApplications { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }

        [ForeignKey("Applicant")]
        [Required]
        public string ApplicantId { get; set; }
        public User Applicant { get; set; }

        public DeputyApplication DeputyApplication { get; set; }
        [NotMapped]
        public User Deputy { get; set; }

        public Answer Answer { get; set; }

        [Required]
        public Status Status { get; set; }        
    }
}
