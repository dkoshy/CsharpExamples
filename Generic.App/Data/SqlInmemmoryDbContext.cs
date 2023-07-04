using Generic.App.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Generic.App.Data
{
    public class SqlInmemmoryDbContext :DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organisation> Organisations => Set<Organisation>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SampleBb");
        }

    }
}