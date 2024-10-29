using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Dtos.Implemento
{
    public class CreateImplementoRequestDto
    {
   
    [Required]
    public int UserId { get; set; } 

    [Required]
    public int HorarioId { get; set; }

    }
}