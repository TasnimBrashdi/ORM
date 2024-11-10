using College.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace College.repositories
{
    public class DepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        //• GetAllDepartments: Retrieve all departments, including the courses they handle and exams conducted.


        public IEnumerable<Department> GetAllDepartments()
        {
            return (from d in _context.Departments select d).Include(d => d.Courses).Include(d => d.Exams)
                   .ToList();
        }


        //• GetDepartmentById: Fetch department details by ID with navigational properties. 

        public Department GetDepartmentById(int depID)
        {
            return _context.Departments.Find(depID);
        }



        //• AddDepartment: Add a new department.
        public void AddCourse(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }


        //• UpdateDepartment: Update details of an existing department.
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }



        //• DeleteDepartment: Delete a department by ID.

        public void DeleteDepartment(int dID)
        {
            var department = GetDepartmentById(dID);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }

        }


        //• GetDepartmentsWithCourses: List departments that offer courses using LINQ Join or Include.
        public IEnumerable<Department> GetDepartmentsWithCourses(int courseId)
        {
            return (from d in _context.Departments where d.Courses.Any(c => c.CId == courseId) select d)
                   .ToList();
        }



        //• GetDepartmentNames: Retrieve just the names of all departments using projection in LINQ.
        public IEnumerable<string> GetDepartmentNames()
        {
            return _context.Departments.Select(d => d.DName)  
           .ToList();
        }


    }
}
