using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }
        [Required]
        public string DName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Exams> Exams { get; set; }

    }
}
