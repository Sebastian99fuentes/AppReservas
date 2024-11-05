using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Models;

namespace api.Repository.Interfaces
{
    public interface IHorarioRepository
    {
        Task<List<Horario>> GetAllAsync();

         Task<Horario?> GetByIdAsync(Guid id); 

         Task<Horario?>  CreateAsync(Horario horario);

         Task<Horario?> UpdateAsync(Guid id, Horario horario );

         Task<Horario?> DeleteAsync(Guid id);
    }
}