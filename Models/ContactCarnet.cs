using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class ContactCarnet
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string AdressStreet { get; set; }
        public int? AdressNumber { get; set; }
        public int? AdressPostalCode { get; set; }
        [StringLength(50)]
        public string AdressCity { get; set; }
        [StringLength(50)]
        public string AdressCountry { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CrationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LasModificationDate { get; set; }
        [Column("IS_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdPeopleNavigation")]
        public virtual People People { get; set; }
        [InverseProperty("IdSocietyNavigation")]
        public virtual Society Society { get; set; }
    }
}
