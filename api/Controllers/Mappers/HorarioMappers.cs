using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comments;
using api.Controllers.Dtos.Horario;
using api.Data.Models;
using api.Models;
using Npgsql.Replication;

namespace api.Controllers.Mappers
{
    public static class HorarioMappers
    {
        public static HorarioDto ToHorarioDto(this Horario horarioModel)
        { 

         var Horario = new HorarioDto
        {
           Id = horarioModel.Id,
           Dia = (Dtos.Horario.DiaSemana)(int)horarioModel.Dia,
           Hora = horarioModel.Hora,
           Disponible = horarioModel.Disponible
        }; 

        if( horarioModel.AreaId.HasValue)
        {
            Horario.AreaId = horarioModel.AreaId;
        }
        else if(horarioModel.ImplementoId.HasValue)
        {
            Horario.ImplementoId = horarioModel.ImplementoId;
        } 

        return Horario;

        }

// Transforma el DTO (CreateUpdateComentRequestDto) en una entidad Comments, que es lo que 
// probablemente necesitas para guardarlo o actualizarlo en la base de datos.
// Usa el id del área (o comentario) que se pasó como parámetro desde la ruta.

        public static Horario ToHorarioFromCreate(this CreateHorarioRequestDto horarioModel, int areaImplementoId, bool esImplemento)
        {

              if (esImplemento)
              {
                   return new Horario
                   {
                       Dia = (Data.Models.DiaSemana)(int)horarioModel.Dia,
                       Hora = horarioModel.Hora,
                       Disponible = true,  // Asumimos que es libre por defecto.
                       ImplementoId = areaImplementoId,
                        AreaId = null  // No tiene área si es implemento.
                    };
               }
                 else
               {
                return new Horario
                   {
                        Dia = (Data.Models.DiaSemana)(int)horarioModel.Dia,
                        Hora = horarioModel.Hora,
                        Disponible = true,
                        AreaId = areaImplementoId,
                        ImplementoId = null  // No tiene implemento si es un área.
                   };
               }
        }

    }
}