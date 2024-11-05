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
        public enum GENDER
        {
            Male,
            Female
        }
        [Key]
        public int Ssn { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string FName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LName { get; set; }

        public string Minit { get; set; }

        public DateTime Bdate { get; set; }
        [EnumDataType(typeof(GENDER))]
        public GENDER Sex { get; set; }
        [Range(200, 10000)]
        public decimal Salary { get; set; }

         public string Address { get; set; }

        [ForeignKey("Supervisor")]
        public int? SuperSsn { get; set; }
        public virtual Employee Supervisor { get; set; }

        [InverseProperty("Supervisor")]
        public virtual ICollection<Employee> Supervisees { get; set; }

        [ForeignKey("Department")]
        public int Dno { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<WorkOn> WorksOnProjects { get; set; }

        public virtual ICollection<Dependents> Dependent { get; set; }





    }
}
