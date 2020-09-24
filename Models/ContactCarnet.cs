using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class ContactCarnet
    {
        public int Id { get; set; }
        public string AdressStreet { get; set; }
        public int? AdressNumber { get; set; }
        public int? AdressPostalCode { get; set; }
        public string AdressCity { get; set; }
        public string AdressCountry { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CrationDate { get; set; }
        public DateTime? LasModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual People People { get; set; }
        public virtual Society Society { get; set; }
    }
}
