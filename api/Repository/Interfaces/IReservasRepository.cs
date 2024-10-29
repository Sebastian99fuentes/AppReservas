using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Area;
using api.Controllers.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IReservasRepository
    {
        
            Task<List<Reserva>> GetAllAsync(int Id);

             Task<Reserva?> GetByIdAsync(int id);  ///first or default cant be null

            Task<Reserva> CreateAsync(Reserva  reserva);

            // Task<Reservas?> UpdateAsync(int id, CreateAreaRequestDto areaDto);

             Task<Reserva?> DeleteAsync(int id); 

              Task<bool> Exist(int id); 
        
    }
}