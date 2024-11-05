using Microsoft.EntityFrameworkCore;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(" Data Source=(local); Initial Catalog=CompanyORM; Integrated Security=true; TrustServerCertificate=True ");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dlocation> Dlocations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkOn> WorksOn { get; set; }
        public DbSet<Dependents> Dependents { get; set; }

    }
}
