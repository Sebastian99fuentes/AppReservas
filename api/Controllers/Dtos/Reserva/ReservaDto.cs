using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comments;

namespace api.Controllers.Dtos.Reserva
{
    public class ReservaDto
    {
        public int Id { get; set; }

         public required  List<HorarioDto> Horarios {get; set; }  // Lista de comentarios

    }
}