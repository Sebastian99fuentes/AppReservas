using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Data.Models
{
  public enum DiaSemana
{
    Domingo = 0,
    Lunes = 1,
    Martes = 2,
    Miércoles = 3,
    Jueves = 4,
    Viernes = 5,
    Sábado = 6
}

public class Horario
{
    public int Id { get; set; }

    public DiaSemana Dia { get; set; }  // Día específico.

    public TimeSpan Hora { get; set; }  // Hora específica (para áreas).

    public bool Disponible { get; set; }  // Indica si el horario está libre.

    // Relación opcional con un área (una cancha, por ejemplo).
    public int? AreaId { get; set; }
    public Area? Area { get; set; }

    // Relación opcional con un implemento (como un balón).
    public int? ImplementoId { get; set; }
    public Implemento? Implemento { get; set; }

    // Método para verificar si el horario aplica a un área o un implemento.
    public bool EsHorarioParaArea => AreaId.HasValue;
}


}