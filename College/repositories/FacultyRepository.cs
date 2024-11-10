using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace College.repositories
{
    public class FacultyRepository
    {
        private readonly AppDbContext _context;

        public FacultyRepository(AppDbContext context)
        {
            _context = context;
        }
        //GetAllFaculties: List all faculty members, including the subjects and courses they are associated with.
        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties.Include(s => s.Subjects).Include(d => d.DEPID).ToList();
        }

        //• GetFacultyById: Fetch a faculty member's complete details by ID, with navigational properties. 

        public Faculty GetFacultyById(int FID)
        {
            return _context.Faculties.Find(FID);
        }
        //• AddFaculty: Add a new faculty member.


        public void AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }
        //• UpdateFaculty: Update the details of an existing faculty member. 

        public void UpdateFaculty(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();

        }

        //• DeleteFaculty: Delete a faculty member by ID. 


        public void DeleteFaculty(int fID)
        {
            var faculty = GetFacultyById(fID);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }

        }
        //• GetFacultyByDepartment: List faculty members based on their department.


        public IEnumerable<Faculty> GetFacultyByDepartment(int DID)
        {
            return _context.Faculties.Include(f => f.DEPID).Where(f => f.DEID == DID)
                 .ToList();
      
        }

        //• GetFacultyByMobileNumber: Search for faculty members by their mobile number. 

        public IEnumerable<Faculty> GetFacultyByMobileNumber(string phone)
        {
            return _context.Faculties.Include(f => f.FPhones).Where(f => f.FPhones.Any(p => p.NUM == phone))
                 .ToList();

        }


        //• CalculateAverageSalary: Use LINQ to calculate the average salary of faculty members.
        public decimal CalculateAverageSalary()
        {
            return (from f in _context.Faculties select f.Salary).Average();
        }




    }
}
