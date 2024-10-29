using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Reservas;
using api.Controllers.Helpers;
using api.Data;
using api.Data.Models;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReservaRepository : IReservasRepository
    {
        private readonly  ApplicationDBContext _context;

        public ImplementoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Reserva>> GetallAsync(int Id)
        {
            //  var reservas = _context.Reserva.Where(u => u.User.id == userId).idInclude(h =>h.horario).AsQueryable();
            
              var reservas = _context.Reserva.Include(h =>h.Horario).AsQueryable().FirstOrDefaultAsync(u => u.userId == Id);

            return await reservas.ToListAsync();
      
        } 

        public async Task<Reserva?> CreateAsync(Reserva reserva)
        {
             await _context.reserva.AddAsync(reserva);
             await _context.SaveChangesAsync();

             return reserva;
        }

         public async Task<Reserva?> DeleteAsync(int id)
        {
           var reserva = _context.Reserva.FirstOrDefault(i => i.Id == id);
           if(implemento == null)
           {
            return null;
           }

           _context.Remove(reserva);
           await _context.SaveChangesAsync();

           return reserva;
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
           return await _context.Reserva.Include(h=>h.Horario).AsQueryable().FirstOrDefaultAsync(x => x.Id== id);
        }

        public Task<bool> Exist(int id)
        {
             return _context.Reserva.AnyAsync(a => a.Id ==id);
        }
    }
}