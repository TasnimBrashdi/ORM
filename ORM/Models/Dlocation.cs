using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    [PrimaryKey(nameof(Dnumber), nameof(Deplocation))]
    public class Dlocation
    {
        [ForeignKey("Department")]
        public int Dnumber { get; set; }
        public virtual Department Department { get; set; }


        public string Deplocation { get; set; }
    }
}
