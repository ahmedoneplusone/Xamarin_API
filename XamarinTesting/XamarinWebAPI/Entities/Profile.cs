using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinWebAPI.Models
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileID { get; set; }
        public int PersonType { get; set; }
        public DateTime FirstHireDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; } 
        public string ServiceLength { get; set; }
        [Phone]
        public string Mobile { get; set; }
        [Phone]
        public string Tel { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Image { get; set; }
        public string JobCategory { get; set; }
        public string Job { get; set; }

    }
}
