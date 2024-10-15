using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Area;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDBContext _context;
        public AreaRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Area>> GetAllAsync()
        {
            return  await _context.Area.Include(c=>c.Comments).ToListAsync();
        }

        public async Task<Area> CreateAsync(Area area)
        {
             await _context.Area.AddAsync(area);
             await  _context.SaveChangesAsync();
             return area;
        }

        public  async Task<Area?> DeleteAsync(int id)
        {
             var areaModel = await _context.Area.FirstOrDefaultAsync(x => x.Id== id);
                if(areaModel == null)
               {
                return null;
               } 

                   _context.Area.Remove(areaModel);
              await  _context.SaveChangesAsync(); 

              return areaModel;
        }

        public async Task<Area?> GetByIdAsync(int id)
        {
           return await _context.Area.Include(c=>c.Comments).FirstOrDefaultAsync(x => x.Id== id);
        }

        public async Task<Area?> UpdateAsync(int id, CreateAreaRequestDto areaDto)
        {
           var existingArea = await _context.Area.FirstOrDefaultAsync(x => x.Id== id);
             if(existingArea == null)
               {
                return null;
               } 
            
              existingArea.Nombre =  areaDto.Nombre;
             existingArea.Descripcion = areaDto.Descripcion;
             existingArea.Ubicacion = areaDto.Descripcion; 

              await  _context.SaveChangesAsync();

              return existingArea;
        }

        public Task<bool> Exist(int id)
        {
            return _context.Area.AnyAsync(a => a.Id ==id);
        }
    }
}