using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("Card")]
    public class Card
    {

        [Key]
        [Required]
        public int Id { get; set; }
       
        public DateTime OpenDate { get; set; }
        public DateTime updateDate { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        private float bmi=0;

        public float Bmi
        {
            get { return bmi; }
            set { bmi= value; }
        }
        public int? SubscriberId { get; set; }
        [ForeignKey(nameof(SubscriberId))]
        public Subscriber Subscriber { get; set; }

    }
}