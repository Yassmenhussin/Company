using Microsoft.EntityFrameworkCore;

namespace Lab1_MVC.Models.Context
{
    public class CompanyContext : DbContext
    {
        public DbSet<Department> departments { get; set; }  
        public DbSet<Employee> employees { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }
        
    }
}
