using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Dlocation
    {
        [ForeignKey("Department")]
        public int Dnumber { get; set; }
        public virtual Department Department { get; set; }


        public string Deplocation { get; set; }
    }
}
