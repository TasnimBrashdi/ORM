using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Subject
    {
        [Key]
        public int SUPID {  get; set; }
        public string SubName { get; set; }

        [ForeignKey("FId")]
        public int? Facid { get; set; }  

        public virtual Faculty FId { get; set; } 

    }
}
