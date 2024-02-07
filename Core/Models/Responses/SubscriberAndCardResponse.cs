using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Responses
{
    public class SubscriberAndCardResponse
    {
        public int SubscriberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
    }
}
