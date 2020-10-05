using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Peoples
{
    public class ClientDetailsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdressStreet { get; set; }
        public int? AdressPostalCode { get; set; }
        public string AdressCity { get; set; }
        public string AdressCountry { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public string Society { get; set; }
    }
}
