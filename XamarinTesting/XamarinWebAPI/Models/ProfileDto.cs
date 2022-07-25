using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinWebAPI.Models
{
    public class ProfileDto
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string FirstHireDate { get; set; }
        public string Mobile { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }

    }
}
