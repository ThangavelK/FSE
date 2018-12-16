using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Person
    {
        [DisplayName("User Id")]
        public string User_id { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Fullname")]
        public string Fullname { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}