using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodManagementCore.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
    }
}
