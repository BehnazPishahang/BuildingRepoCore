using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Authentication
{
    public class AuthenticationRequest
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Family { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }
    }
}
