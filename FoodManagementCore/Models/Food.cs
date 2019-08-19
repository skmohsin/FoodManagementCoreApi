using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodManagementCore.Models
{

    [Table("Food")]
    public class Food
    {
        [Key]
        public int FoodID { get; set; }
        public string Name { get; set; }
        public decimal Price{ get; set; }
        public string Picture { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public bool IsActive { get; set; }
    }
}
