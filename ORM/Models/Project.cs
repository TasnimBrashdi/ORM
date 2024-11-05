using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Project
    {
        [Key]
        public int Pnumber { get; set; }

        [Required]
      
        public string Pname { get; set; }
        public string Plocation { get; set; }

        [ForeignKey("Department")]
        public int Dnum { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<WorkOn> WorkEmployees { get; set; }



    }
}
