using DNPAssigment1.Login;
using DNPAssigment1.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DNPAssigment2.Persistance
{
    public class Context: DbContext
    {
        public DbSet<User> AUsers { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite("Data Source = FamilySystem.db");
        }
        
    }
}