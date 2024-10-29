using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Implemento;
using api.Controllers.Helpers;
using api.Data.Models;

namespace api.Repository.Interfaces
{
    public interface IImplementosRepository
    {
        Task <List<Implemento>>  GetallAsync(QueryObject query); 

        Task<Implemento?> GetByIdAsync(int id);

        Task <Implemento?> CreateAsync(Implemento implemento);

        Task <Implemento?> UpdateAsync(int id, CreateImplementoRequestDto implementoDto);

        Task<Implemento?> DeleteAsync(int id);
        Task<bool> Exist(int id);  
        
    }
}