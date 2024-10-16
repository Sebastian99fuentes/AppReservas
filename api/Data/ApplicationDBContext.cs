using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
        {
            
        }
        
        public DbSet<Area> Area {get; set; }
        public DbSet<Comments> Comments {get; set; } 


         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para almacenar CreatedOn como UTC
            modelBuilder.Entity<Comments>()
                .Property(c => c.CreatedOn)
                .HasConversion(
                    v => v.ToUniversalTime(), // Almacena en UTC
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Devuelve en UTC
                );
        }
    }
}