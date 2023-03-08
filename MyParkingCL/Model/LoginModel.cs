using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyParkingCL.Model
{
    public class LoginModel
    {

        [Required]
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PassWord { get; set; }

    }
}