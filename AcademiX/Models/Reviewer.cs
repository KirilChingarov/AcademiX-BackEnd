﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
    public class Reviewer 
    {
        [Key]
        [Required]
        public int Id { get; set; }       

        public int Cabinet { get; set; }

        [StringLength(7)]
        public string WorkingTime { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
