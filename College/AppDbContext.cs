using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College
{
    internal class AppDbContext : DbContext 

    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(" Data Source=(local); Initial Catalog=CollegeORM; Integrated Security=true; TrustServerCertificate=True ");
        }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Subject> subjects { get; set; }
        public DbSet<FPhone> fPhones { get; set; }
        public DbSet<SPhone> SPhones { get; set; }
        public DbSet<Hostel> Hostels { get; set; }

        public DbSet<Exams> Exams { get; set; }


    }
}
