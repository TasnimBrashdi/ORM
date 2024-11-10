using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    [PrimaryKey(nameof(StuID), nameof(SuNum))]
    public class SPhone
    {
        [ForeignKey("SUTID")]
        public int StuID { get; set; }

        public virtual Student SUTID { get; set; }
        public string SuNum { get; set; }
    }
}
