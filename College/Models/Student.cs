using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string FName { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string LName { get; set; }

        public string City { get; set; }
        [Required]
        public string PinCode { get; set; }


        public DateTime DOB { get; set; }
        [ForeignKey("FACID")]
        public int FacId { get; set; }
        public Faculty FACID { get; set; }
       

        [ForeignKey("HostelID")]
        public int? hosID { get; set; }

        public virtual  Hostel HostelID { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SPhone> sPhones {  get; set; }
        public virtual ICollection<Exams> Exams { get; set; }
    }
   
}
