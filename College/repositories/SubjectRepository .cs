using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace College.repositories
{
    public class SubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        //• GetAllSubjects: Retrieve all subjects and include the faculty members associated with each subject.

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.subjects.Include(s => s.FId);
        }

        //• GetSubjectById: Fetch a specific subject by ID with navigational properties.
        public Subject GetSubjectById(int subID)
        {
            return _context.subjects.Find(subID);
        }

        //• AddSubject: Add a new subject to the database.

        public void AddSubject(Subject sub)
        {
            _context.subjects.Add(sub);
            _context.SaveChanges();
        }
        //• UpdateSubject: Update details of an existing subject. 

        public void UpdateSubject(Subject subject)
        {
            _context.subjects.Update(subject);
            _context.SaveChanges();

        }

        //• DeleteSubject: Delete a subject by ID.

        public void DeleteSubject(int sID)
        {
            var subject = GetSubjectById(sID);
            if (subject != null)
            {
                _context.subjects.Remove(subject);
                _context.SaveChanges();
            }

        }

        //• GetSubjectsTaughtByFaculty: List subjects taught by a specific faculty member using LINQ.
        public IEnumerable<Subject> GetSubjectsTaughtByFaculty(int facultyId)
        {
            return (from s in _context.subjects where s.Facid == facultyId select s)
                   .ToList();
        }

        //• CountSubjects: Use LINQ to get the total number of subjects offered.

        public int CountSubjects()
        {
            return _context.subjects.Count();
        }

    }
}
