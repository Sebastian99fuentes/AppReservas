using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.Models;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    // public class ApplicationDBContext: DbContext
     public class ApplicationDBContext: IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        : base(dbContextOptions)
        {
            
        }
        
        public DbSet<Area> Area {get; set; }
        public DbSet<Comments> Comments {get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name ="Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                {
                    Name ="User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


   // Configuración para almacenar CreatedOn como UTC
            builder.Entity<Comments>()
                .Property(c => c.CreatedOn)
                .HasConversion(
                    v => v.ToUniversalTime(), // Almacena en UTC
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Devuelve en UTC
                );


        }

    }
}