using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}