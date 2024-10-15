using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Dtos.Comments
{
    public class CreateComentRequestDto
    {
        public string Titulo {get; set; } = string.Empty;
        public string Comentario {get; set;}= string.Empty;

    }
}