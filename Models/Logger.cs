using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Logger
    {
        public int IdLog { get; set; }
        public string TypeLog { get; set; }
        public DateTime DateLog { get; set; }
        public string Description { get; set; }
    }
}
