using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTesting.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public int PersonType { get; set; }
        public DateTime FirstHireDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ServiceLength { get; set; }
         public string Mobile { get; set; }
         public string Tel { get; set; }
         public string Email { get; set; }
        public string Job { get; set; }
        public string JobCategory { get; set; }

        public string Image { get; set; }
    }
}
