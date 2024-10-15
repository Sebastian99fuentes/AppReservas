using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers.Dtos.Area
{
    public class CreateAreaRequestDto
    {
        
        public string Nombre { get; set; } = string.Empty;         // Nombre de la cancha, sala, etc.
        public string Ubicacion { get; set; }  = string.Empty;       // Ubicación del espacio 
        public string Descripcion { get; set; } = string.Empty;     // Descripción adicional

    }
}