using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Exams
    {
        [Key]
        public string ExCode {  get; set; }
        [Required]
        public string Room { get; set; }

        public DateOnly date { get; set; }

        public TimeOnly time { get; set; }

        [ForeignKey("DEPId")]
        public int DEPtId { get; set; }
        public virtual Department DEPId { get; set; }
  
    }
}
