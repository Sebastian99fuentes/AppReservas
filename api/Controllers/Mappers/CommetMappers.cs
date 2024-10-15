using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Comments;
using api.Models;
using Npgsql.Replication;

namespace api.Controllers.Mappers
{
    public static class CommetMappers
    {
        public static CommentDto ToCommentDto(this Comments commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                
                Titulo = commentModel.Titulo,
                
                Comentario = commentModel.Comentario,
                
                CreatedOn = commentModel.CreatedOn,
                //FK
                AreaId = commentModel.AreaId

            };
        }


        public static CommentDto ToCommentFromCreate(this CreateComentRequestDto commentModel, int areaId)
        {
            return new CommentDto
            {
   
                Titulo = commentModel.Titulo,
                
                Comentario = commentModel.Comentario,
                //FK
                AreaId = areaId

            };
        }
    }
} 


