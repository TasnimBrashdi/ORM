using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using College.Models;
using System.Runtime.Intrinsics.X86;

namespace College.Repositories
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(s => s.Courses).Include(s => s.HostelID).Include(s => s.sPhones)
                //Exams    
                .ToList();
        }
        public Student GetStudentById(int sID)
        {
            return _context.Students.Find(sID);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

        }
        public void DeleteStudent(int sID)
        {
            var student = GetStudentById(sID);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

        }

      
        public IEnumerable<Student> GetStudentsByCourse(int CoudrseID)
        {
            return _context.Students.Include(s => s.Courses).Where(s => s.Courses.Any(c => c.CId == CoudrseID))
              .ToList();
        }

        public IEnumerable<Student> GetStudentsInHostel(int hostelID)
        {
            return _context.Students.Where(s => s.hosID == hostelID)
                .ToList();
        }

        public IEnumerable<Student> SearchStudents(string name = null, string num = null)
        {


            var student = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                student = student.Where(s => s.FName.Contains(name) || s.LName.Contains(name));
            }


            if (!string.IsNullOrEmpty(num))
            {
                student = student.Where(s => s.sPhones.Any(p => p.SuNum.Contains(num)));
           
            }
            return student.ToList();
        }
        public IEnumerable<Student> GetStudentsWithAgeAbove(int age)
        {
            var currentDate = DateTime.Today; 

            return _context.Students.Where(s => (currentDate.Year - s.DOB.Year) - (currentDate < s.DOB.AddYears(currentDate.Year - s.DOB.Year) ? 1 : 0) > age)
                .ToList();
        }
    }
}


