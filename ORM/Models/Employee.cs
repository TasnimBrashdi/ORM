using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Employee
    {
        [Key]
        public int Ssn { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

        public string Minit { get; set; }

        public DateTime Bdate { get; set; }

        public string Sex { get; set; } 
        public decimal Salary { get; set; }

         public string Address { get; set; }

        [ForeignKey("Supervisor")]
        public int? SuperSsn { get; set; }
        public virtual Employee Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual ICollection<Employee> Supervisees { get; set; }

    }
}
