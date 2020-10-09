using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO
{
    public class ProjectPartialListDTO
    {
        public int IdProject { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public System.DateTime? CreationDate { get; set; }
        public System.DateTime? StartDate { get; set; }
        public string Society { get; set; }
    }
}
