using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Dtos.Horario
{

    public class CreateHorarioRequestDto
    {

        [Required]
        public int Dia { get; set; }  // Día específico.

        [Required]
        public int Hora { get; set; }  // Hora específica (para áreas).

         [Required]
        public bool EsImplemento { get; set; }  // Flag para saber si es un implemento   
    }
}