using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Implemento;
using api.Controllers.Helpers;
using api.Data;
using api.Data.Models;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ImplementoRepository : IImplementosRepository
    {
        private readonly  ApplicationDBContext _context;

        public ImplementoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Implemento>> GetallAsync(QueryObject query)
        {
             var implementos = _context.Implemento.Include(c =>c.Comments).AsQueryable();

             if(!string.IsNullOrWhiteSpace(query.ImplementoNombre))
             {
                implementos = implementos.Where( i=> i.NombreImple ==query.ImplementoNombre);
             }
               else
            {
                // Orden por defecto para evitar advertencias de EF Core
              implementos = implementos.OrderBy(a => a.Id); // Asumiendo que 'Id' es una clave única
            } 

                        var skipNumber = (query.PageNumber-1) * query.PageSize;

            return  await  implementos.Skip(skipNumber).Take(query.PageSize).ToListAsync();

        } 

        public async Task<Implemento?> CreateAsync(Implemento implemento)
        {
             await _context.Implemento.AddAsync(implemento);
             await _context.SaveChangesAsync();

             return implemento;
        }

        public  async Task<Implemento?> UpdateAsync(int id, CreateImplementoRequestDto implementoDto)
        {
           var existingImplemento = await _context.Implemento.FirstOrDefaultAsync(i => i.Id == id);
               if(existingImplemento == null)
                {
                    return null;
                }
               existingImplemento.NombreImple = implementoDto.NombreImple;
               existingImplemento.Cantidad = implementoDto.Cantidad;

                await _context.SaveChangesAsync();

               return existingImplemento; 

        }

         public async Task<Implemento?> DeleteAsync(int id)
        {
           var implemento = _context.Implemento.FirstOrDefault(i => i.Id == id);
           if(implemento == null)
           {
            return null;
           }

           _context.Remove(implemento);
           await _context.SaveChangesAsync();

           return implemento;
        }

        public async Task<Implemento?> GetByIdAsync(int id)
        {
           return await _context.Implemento.Include(c=>c.Comments).AsQueryable().FirstOrDefaultAsync(x => x.Id== id);
        }
    }
}