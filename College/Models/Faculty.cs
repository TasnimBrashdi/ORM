using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Name { get; set; }

        [ForeignKey("DEPID")]
        public int DEID { get; set; }
        public virtual Department DEPID { get; set; }


        public decimal Salary { get; set; }
  
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<FPhone> FPhones { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
