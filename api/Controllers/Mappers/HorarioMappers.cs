using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comments;
using api.Models;
using Npgsql.Replication;

namespace api.Controllers.Mappers
{
    public static class HorarioMappers
    {
        public static horarioDto ToHorarioDto(this horario horarioModel)
        {
            return new horarioDto
            {
                Id = horarioModel.Id,
                
                DiaSemana = horarioModel.DiaSemana.Dia,

                Hora = horarioModel.Hora,
                
                Disponible = commentModel.Disponible,
                
            
                //FK
                AreaId = horarioModel.AreaId,

                ImplementoId = horarioModel.ImplementoId

            };
        }

// Transforma el DTO (CreateUpdateComentRequestDto) en una entidad Comments, que es lo que 
// probablemente necesitas para guardarlo o actualizarlo en la base de datos.
// Usa el id del área (o comentario) que se pasó como parámetro desde la ruta.

        public static Horario ToHorarioFromCreate(this CreateHorarioRequestDto horarioModel, int areaImplementoId)
        {
            return new Horario
            {
   
                Dia = horarioModel.Dia,
                
                Hora = horarioModel.Hora,

                //FK
                AreaId? = areaImplementoId,

                ImplementoId = areaImplementoId
            };
        }


    }
}