using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace College.repositories
{
    public class CourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        // • GetAllCourses: Retrieve all courses, including students enrolled and faculty handling the course.

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.Students).Include(c => c.Faculties)
                .ToList();
        }


        //• GetCourseById: Fetch course details by ID, with related students and faculties.

        public Course GetCourseById(int CousrsID)
        {
            return _context.Courses.Find(CousrsID);
        }

        //• AddCourse: Add a new course to the database.

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        //• UpdateCourse: Update existing course details. 


        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();

        }
        //• DeleteCourse: Delete a course by ID.

        public void DeleteCourse(int cID)
        {
            var course = GetCourseById(cID);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }

        }

        //• GetCoursesByDepartment: List courses offered by a specific department.
        public IEnumerable<Course> GetCoursesByDepartment(int IDDEP)
        {
            return (from c in _context.Courses where c.DeptID == IDDEP select c)
                   .ToList();
        }


        //• GetCoursesWithDuration: Filter courses by their duration using LINQ. 
        public IEnumerable<Course> GetCoursesWithDuration(int dur)
        {
            return (from c in _context.Courses where c.Duration == dur select c)
                   .ToList();
        }


        //• PaginateCourses: Implement pagination to handle a large number of courses.
    }
}
