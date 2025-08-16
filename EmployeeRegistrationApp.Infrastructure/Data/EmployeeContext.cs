using EmployeeRegistrationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Infrastructure.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> opts)
            : base(opts) { }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Employee>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
                e.Property(x => x.LastName).IsRequired().HasMaxLength(50);
                e.Property(x => x.Email).IsRequired();
            });

            // Example stored procedure mapping (EF Core 7+)
            //mb.Entity<Employee>().HasNoKey().ToFunction("GetEmployeesByDept");
            mb.Entity<Employee>().HasKey(e => e.Id); // ✅ Optional but clear
        }
    }
}
