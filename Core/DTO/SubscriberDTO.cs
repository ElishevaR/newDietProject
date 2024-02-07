using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public record SubscriberDTO(

        [Required(ErrorMessage = "TZ IS Must")]
        string Password,
        string FirstName,
        string LastName,
        string Email,
        float Height
        );

}
