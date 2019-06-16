﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Submission
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string ProblemId { get; set; }
        public Problem Problem { get; set; }
    }
}
