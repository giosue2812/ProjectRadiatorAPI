using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO
{
    public class ProjectShortDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SocietyShortDTO Society { get; set; }
        public TypeStagesShortDTO TypeStages { get; set; }
    }
}
