using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Horario;
using api.Controllers.Mappers;
using api.Interfaces;
using api.Repository;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/horario")] 
    [ApiController]
    public class HorarioController : ControllerBase
    {
         private readonly IHorarioRepository _IHorarioRepository;
         private readonly IAreaRepository _IAreaRepository;
         private readonly IImplementosRepository _IImplementoRepository;

        public HorarioController(  IHorarioRepository horarioRepository, IAreaRepository areaRepository, IImplementosRepository implementoRepository)
        {
            _IHorarioRepository = horarioRepository;
            _IAreaRepository = areaRepository;
            _IImplementoRepository = implementoRepository;
        } 

        [HttpGet("por-area-o-implemento/{AreaOImplementoId:guid}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid AreaOImplementoId)
        {
            var horarios = await _IHorarioRepository.GetAllAsync(AreaOImplementoId);
            
             var horarioDto = horarios.Where(x => x.Disponible == true).Select(c => c.ToHorarioDto());
 
            return Ok(horarioDto);

        }

         [HttpGet("horariosById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var horarios = await _IHorarioRepository.GetByIdAsync(id);
            
            if(horarios == null)
            {
                return NotFound();
            }

            return Ok(horarios.ToHorarioDto());

        }

        [HttpPost("Create-horario/{AreaOImplementoId:guid}")]
        public async Task<IActionResult> Create([FromRoute] Guid AreaOImplementoId, CreateHorarioRequestDto horarioDto)
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (horarioDto.Dia < 0 || horarioDto.Dia > 7)
                 return BadRequest("El día debe estar en el rango de 0 a 7.");

            if(horarioDto.EsImplemento)
            {
                if(!await _IImplementoRepository.Exist(AreaOImplementoId))
                    return BadRequest("Implemento no existe");

            } 
            else
            {
                 if(!await _IAreaRepository.Exist(AreaOImplementoId))
                     return BadRequest("Area no existe"); 

                 if (horarioDto.Hora < 8 || horarioDto.Hora > 20)
                  return BadRequest("La hora debe estar en el rango de 8:00 a 20:00.");    

            }        
            
            var horariosCreados = await _IHorarioRepository.GetAllAsync(AreaOImplementoId);

            bool horarioExiste = horariosCreados.Any(h => h.Hora ==horarioDto.Hora && h.Dia == horarioDto.Dia);

            if(horarioExiste)
                return BadRequest("el horario ya existe");
            try
            {
             var horarioModel = horarioDto.ToHorarioFromCreate(AreaOImplementoId,horarioDto.EsImplemento);

            await _IHorarioRepository.CreateAsync(horarioModel);

            return CreatedAtAction(nameof(GetById), new { id = horarioModel.Id }, horarioModel.ToHorarioDto());

            }
            catch(Exception e)
            {
                 return StatusCode(500, $"Error al crear el horario: {e.Message}");
            }
           
        }


        [HttpPut]
        [Route("Update-horario{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            
             // Verificar si el horario existe
             var horario = await _IHorarioRepository.GetByIdAsync(id);
              if (horario == null)
                   return NotFound("El horario no existe");

            var updatedHorario = await _IHorarioRepository.UpdateAsync(id);


            // if (updatedHorario.ImplementoId.HasValue)
            // {
            //     Guid implementoId = updatedHorario.ImplementoId.Value;
            //     await _IImplementoRepository.UpdateAsync(implementoId);
            // }
            // else
            // {
            //     return BadRequest("ImplementoId no puede ser nulo.");
            // }
             
                if (updatedHorario == null)
                     return StatusCode(500, "No se pudo actualizar el horario"); 

            return Ok(horario.ToHorarioDto());
        }


        [HttpDelete]
        [Route("Delete-horario{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        { 

            var horarioModel = await _IHorarioRepository.DeleteAsync(id);

            if(horarioModel == null)
            {
                return NotFound("Comment does not exist");
            }

            return Ok();

        }

    }
}