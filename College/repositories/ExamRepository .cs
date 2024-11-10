using College.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace College.repositories
{
    public class ExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        //• GetAllExams: List all exams, including the department and students taking the exam.
        public IEnumerable<Exams> GetAllExams()
        {
            return _context.Exams.Include(e => e.DEPId)              
                .ToList();
        }


        //• GetExamById: Fetch exam details by ID with navigational properties. 

        public Exams GetExamById(int EID)
        {
            return _context.Exams.Find(EID);
        }
        //• AddExam: Add a new exam.

        public void AddExam(Exams exams)
        {
            _context.Exams.Add(exams);
            _context.SaveChanges();
        }
        //• UpdateExam: Modify the details of an existing exam.
        public void UpdateExam(Exams exams)
        {
            _context.Exams.Update(exams);
            _context.SaveChanges();
        }



        //• DeleteExam: Delete an exam by ID.

        public void DeleteExam(int EID)
        {
            var exams = GetExamById(EID);
            if (exams != null)
            {
                _context.Exams.Remove(exams);
                _context.SaveChanges();
            }

        }

        //• GetExamsByDate: Filter exams by a specific date or date range using LINQ. 

        public IEnumerable<Exams> GetExamsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            return _context.Exams.Where(e => e.date >= startDate && e.date <= endDate).Include(e => e.DEPId)                                 
                .ToList();
        }

        //• GetExamsByStudent: List exams taken by a specific student.

        public IEnumerable<Exams> GetExamsByStudent(int studentId)
        {
            return (from e in _context.Exams where e.Students.Any(s => s.SId == studentId) select e)
              .Include(e => e.DEPId)
              .ToList();
        }

        //• CountExamsByDepartment: Count the number of exams conducted by a specific department.


        public int CountExamsByDepartment(int departmentId)
        {
            return (from e in _context.Exams where e.DEPtId == departmentId select e).Count();
        }

    }
}
