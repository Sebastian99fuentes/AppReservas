using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Horario;
using api.Controllers.Mappers;
using api.Interfaces;
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
        public HorarioController(  IHorarioRepository horarioRepository, IAreaRepository areaRepository)
        {
            _IHorarioRepository = horarioRepository;
            _IAreaRepository = areaRepository;
            
        } 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var horarios = await _IHorarioRepository.GetAllAsync();
            
            var horarioDto = horarios.Select(c => c.ToHorarioDto());

            return Ok(horarioDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var horarios = await _IHorarioRepository.GetByIdAsync(id);
            
            if(horarios == null)
            {
                return NotFound();
            }

            return Ok(horarios.ToHorarioDto());

        }

        [HttpPost("{AreaId:int}")]
        public async Task<IActionResult> Create([FromRoute] int AreaId, CreateUpdateComentRequestDto comenDto)
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _IAreaRepository.Exist(AreaId))
            {
                return BadRequest("Area no existe");
            } 

            var commentModel = comenDto.ToCommentFromCreate(AreaId);

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateUpdateComentRequestDto ComenDto )
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
             
             
            var comment = await _commentRepository.UpdateAsync(id, ComenDto.ToCommentFromCreate(id));

            if(comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delette([FromRoute] int id)
        { 

            var commentModel = await _commentRepository.DeleteAsync(id);

            if(commentModel == null)
            {
                return NotFound("Comment does not exist");
            }

            return Ok();

        }

    }
}