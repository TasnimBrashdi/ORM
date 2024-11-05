using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ORM.Models.Employee;

namespace ORM.Models
{
    [PrimaryKey(nameof(Essn), nameof(DepndentName))]
    public class Dependents
    {
        public enum GENDERd
        {
            Male,
            Female
        }
        [ForeignKey("Employee")]
        public int Essn { get; set; }
        public virtual Employee Employee { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string DepndentName { get; set; }
        [EnumDataType(typeof(GENDERd))]
        public GENDERd DSex { get; set; }

        public DateTime DBdate { get; set; }

        public string Relationship { get; set; }

    }
}
