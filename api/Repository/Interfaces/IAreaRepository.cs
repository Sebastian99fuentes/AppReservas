using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Area;
using api.Controllers.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IAreaRepository
    {
        
            Task<List<Area>> GetAllAsync(QueryObject query);

             Task<Area?> GetByIdAsync(int id);  ///first or default cant be null

            Task<Area> CreateAsync(Area area);

             Task<Area?> UpdateAsync(int id, CreateAreaRequestDto areaDto);

             Task<Area?> DeleteAsync(int id); 

             Task<bool> Exist(int id); 
        
    }
}