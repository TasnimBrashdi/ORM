using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Department
    {
        [Key]
        public int Dnumber { get; set; }
        public string DName { get; set; }

        [ForeignKey("Manager")]
        public int Mgrssn { get; set; }

        public virtual Employee Manager { get; set; }

        public DateTime MStartDate { get; set; }



    }
}
