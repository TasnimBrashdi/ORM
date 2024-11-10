using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public   class Course
    {
        [Key]
        public int CId { get; set; }
        [Required]
        public string CName { get; set; }


        public int Duration { get; set; }
        [ForeignKey("DepID")]
        public int DeptID { get; set; }

        public virtual Department DepID { get; set; }

        public virtual  ICollection<Student> Students { get; set; }



    }
}
