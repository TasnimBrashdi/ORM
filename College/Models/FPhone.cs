using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    [PrimaryKey(nameof(fcId), nameof(NUM))]
    public class FPhone
    {
        [ForeignKey("IDF")]
        public int fcId { get; set; }

        public string NUM { get; set; }
        public virtual Faculty IDF { get; set; }
      

    }
}
