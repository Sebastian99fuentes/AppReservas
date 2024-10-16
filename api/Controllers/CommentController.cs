using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comments;
using api.Controllers.Mappers;
using api.Interfaces;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")] 
    [ApiController]
    public class CommentController : ControllerBase
    {
         private readonly ICommentRepository _commentRepository;
         private readonly IAreaRepository _IAreaRepository;
        public CommentController(  ICommentRepository commentRepository, IAreaRepository areaRepository)
        {
            _commentRepository = commentRepository;
            _IAreaRepository = areaRepository;
            
        } 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            
            var commentDto = comments.Select(c => c.ToCommentDto());

            return Ok(commentDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comments = await _commentRepository.GetByIdAsync(id);
            
            if(comments == null)
            {
                return NotFound();
            }

            return Ok(comments.ToCommentDto());

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