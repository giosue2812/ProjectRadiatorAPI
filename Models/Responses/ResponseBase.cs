using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class ResponseBase
    {
        public int Status { get; set; } = 200;
        public bool IsSucess { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
