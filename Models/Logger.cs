using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Logger
    {
        [Key]
        public int IdLog { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeLog { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateLog { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
