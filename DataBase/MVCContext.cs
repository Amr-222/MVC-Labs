using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.DataBase
{
    public class MVCContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVCDay1;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
