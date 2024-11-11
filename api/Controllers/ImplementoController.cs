using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Area;
using api.Controllers.Dtos.Implemento;
using api.Controllers.Helpers;
using api.Controllers.Mappers;
using api.Data;
using api.Data.Models;
using api.Interfaces;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api.Controllers
{
    [Route("api/implementos")]
     [ApiController]
    public class ImplementoController : ControllerBase
    {
        private readonly  IImplementosRepository _implementoRepository;

        public ImplementoController(IImplementosRepository implementosRepository)
        {
             _implementoRepository = implementosRepository;
        }

        [HttpGet ("GetAll-implemento")]
        public async Task<IActionResult> GetAll ([FromQuery] QueryObject query)
        {
            var implemento = await _implementoRepository.GetallAsync(query);
            
            var implementoDto =  implemento.Select(i => i.ToimplementosDto());

            return Ok(implementoDto);
        }

        [HttpGet("ById -implemento{id:guid}")]
        public async Task<IActionResult> GetById ([FromRoute] Guid id)
        {
            var implemento = await _implementoRepository.GetByIdAsync(id);

            if(implemento == null)
            {
                return NotFound();
            }

            return Ok(implemento.ToImplementoDto());

        }

        [HttpPost("create-implemento")]
        public async Task<IActionResult> Create ([FromBody] CreateImplementoRequestDto implementoDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var implementoModel = implementoDto.ToImplementoFromCreateDto();
                await _implementoRepository.CreateAsync(implementoModel);

                return CreatedAtAction(nameof(GetById),new{id =implementoModel.Id},implementoModel.ToImplementoDto());
        }

        [HttpPut]
        [Route("Update-implemento{id:guid}")]

        public async Task<IActionResult> Update ([FromRoute] Guid id, [FromBody] CreateImplementoRequestDto Implemento)
        {
            if(!ModelState.IsValid)
                    return BadRequest(ModelState); 

                    var implementoModel = await _implementoRepository.UpdateAsync(id, Implemento);
                    
                    if(implementoModel == null)
                    {
                        return NotFound();
                    }

                    return Ok(Implemento);
        } 


        [HttpDelete]
        [Route("Delete-implemento{id:guid}")] 

        public async Task<IActionResult> Delete ([FromRoute] Guid id)
        {
            var implemento = await _implementoRepository.DeleteAsync(id);

            if(implemento == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}