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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var horarios = await _IHorarioRepository.GetAllAsync();
            
            var horarioDto = horarios.Select(c => c.ToHorarioDto());

            return Ok(horarioDto);

        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var horarios = await _IHorarioRepository.GetByIdAsync(id);
            
            if(horarios == null)
            {
                return NotFound();
            }

            return Ok(horarios.ToHorarioDto());

        }

        [HttpPost("{AreaId:guid}")]
        public async Task<IActionResult> Create([FromRoute] Guid AreaId, CreateHorarioRequestDto horarioDto)
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(horarioDto.EsImplemento)
            {
                if(!await _IImplementoRepository.Exist(AreaId))
                    return BadRequest("Implemento no existe");

            } 
            else
            {
                 if(!await _IAreaRepository.Exist(AreaId))
                     return BadRequest("Area no existe"); 

            }        
            
            var horarioModel = horarioDto.ToHorarioFromCreate(AreaId,horarioDto.EsImplemento);

            await _IHorarioRepository.CreateAsync(horarioModel);

            return CreatedAtAction(nameof(GetById), new { id = horarioModel.Id }, horarioModel.ToHorarioDto());
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateHorarioRequestDto horarioDto )
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(horarioDto.EsImplemento)
            {
                if(!await _IImplementoRepository.Exist(id))
                    return BadRequest("Implemento no existe");

            } 
            else
            {
                 if(!await _IAreaRepository.Exist(id))
                     return BadRequest("Area no existe"); 

            }        
            var horario = await _IHorarioRepository.UpdateAsync(id, horarioDto.ToHorarioFromCreate(id,horarioDto.EsImplemento));

            if(horario == null)
            {
                return NotFound("horario no se pudo actualizar");
            }

            return Ok(horario.ToHorarioDto());
        }


        [HttpDelete]
        [Route("{id:guid}")]
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