using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Models;

namespace api.Models
{
    public class Comments
    {
        public int  Id  {get; set; }
        public string Titulo {get; set; } = string.Empty;
        public string Comentario {get; set;}= string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;
        
        // Navigation 
        public int? AreaId {get; set; }     // Navigation 
        public Area? Area {get; set; }


           // Navigation 
        public int? ImplementoId {get; set; }     // Navigation 
        public Implemento? Implemento {get; set; }
    }
}