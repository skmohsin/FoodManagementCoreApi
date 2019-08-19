using FoodManagementCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodManagementCore
{
    public class FoodManagementContext : DbContext
    {
        public FoodManagementContext(DbContextOptions<FoodManagementContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
