﻿using System.ComponentModel.DataAnnotations;

namespace JobCandidateHub.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}