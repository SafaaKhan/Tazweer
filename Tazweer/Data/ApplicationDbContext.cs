using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tazweer.Models;

namespace Tazweer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LostPassportInformation> LostPassportInformation { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<DocumentsType> DocumentsType { get; set; }
    }
}