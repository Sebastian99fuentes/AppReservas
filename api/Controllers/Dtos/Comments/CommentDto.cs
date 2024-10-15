using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Dtos.Comments
{
    public class CommentDto
    {
        public int  Id  {get; set; }
        public string Titulo {get; set; } = string.Empty;
        public string Comentario {get; set;}= string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;
        
        // Navigation 
        //FK
        public int? AreaId {get; set; }     // Navigation 
    }
}