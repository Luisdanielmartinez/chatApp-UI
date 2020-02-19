using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Models
{
   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Tell { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhotoPerfile { get; set; }
    }
}
