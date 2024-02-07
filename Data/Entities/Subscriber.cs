using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data.Model
{
    [Table("Subscriber")]
    public class Subscriber
    {
        [Key]
        [Required]
         public int Id { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        [RegularExpression("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Invalid EMail")]
        public string Email { get; set; }
        [Required]
        [StringLength(9)]
        public string Password { get; set; }

    }
}
