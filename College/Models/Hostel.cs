using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Hostel
    {

        [Key]
        public int HID { get; set; }
        [Required]
        public string HName { get; set; }
         public int NOSeats { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
