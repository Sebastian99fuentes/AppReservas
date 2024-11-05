using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Data.Models;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDBContext _context;
        public HorarioRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Horario?> CreateAsync(Horario horario)
        {
           await _context.Horario.AddAsync(horario);
           await _context.SaveChangesAsync();
           return horario;
        }

        public async Task<Horario?> DeleteAsync(Guid id)
        {
          var existeHorario = await _context.Horario.FirstOrDefaultAsync(h => h.Id == id);
          if(existeHorario == null)
          {
            return null;
          } 

          _context.Horario.Remove(existeHorario);
         await _context.SaveChangesAsync();

         return existeHorario;

        }

        public async Task<List<Horario>> GetAllAsync()
        {
            return await _context.Horario.ToListAsync();
        }

        public async Task<Horario?> GetByIdAsync(Guid id)
        {
           return await _context.Horario.FirstOrDefaultAsync( h => h.Id == id);
        }

        public async Task<Horario?> UpdateAsync(Guid id, Horario horariodto)
        {
           var existehorario = await _context.Horario.FirstOrDefaultAsync(h =>h.Id == id);
           if(existehorario == null)
           {
            return null;
           }

            existehorario.Disponible = horariodto.Disponible; 

            await _context.SaveChangesAsync();

            return existehorario;
        }
    }
}