using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace College.repositories
{
    public class HostelRepository
    {
        private readonly AppDbContext _context;

        public HostelRepository(AppDbContext context)
        {
            _context = context;
        }

        // GetAllHostels: Retrieve all hostel information, including the list of students associated with each hostel.

        public IEnumerable<Hostel> GetAllHostels()
        {
            return _context.Hostels.Include(h => h.Students)  
                 .ToList();
        }


        //• GetHostelById: Fetch details of a specific hostel, including navigational properties for associated students. 
        public Hostel GetHostelById(int hID)
        {
            return _context.Hostels.Find(hID);
        }


        //• AddHostel: Add a new hostel.

        public void AddHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
        }

        //• UpdateHostel: Modify an existing hostel's details.
        public void UpdateHostel(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            _context.SaveChanges();

        }


        //• DeleteHostel: Remove a hostel by ID and ensure no orphaned student data.

        public void DeleteHostel(int hID)
        {
            var hote = GetHostelById(hID);
            if (hote != null)
            {
                _context.Hostels.Remove(hote);
                _context.SaveChanges();
            }

        }
        //• GetHostelsByCity: List hostels in a specific city using LINQ. 


        //public IEnumerable<Hostel> GetHostelsByCity(string city)
        //{
                       
        //}

        //• CountHostelsWithAvailableSeats: Provide a count of hostels that have available seats using Count.
        public int CountHostelsWithAvailableSeats()
        {
            return _context.Hostels.Count(h => h.NOSeats > h.Students.Count);
        }
    }
}