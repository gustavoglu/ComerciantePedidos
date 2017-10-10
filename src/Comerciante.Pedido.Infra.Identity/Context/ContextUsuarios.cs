using Comerciante.Pedido.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Comerciante.Pedido.Infra.Identity.Context
{
    public class ContextUsuarios : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Altera nome de tabelas do Entity
            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<IdentityUser>().ToTable("Usuario");
            builder.Entity<IdentityUserRole<string>>().ToTable("Usuario_Regra");
            builder.Entity<IdentityUserLogin<string>>().ToTable("Login");
            builder.Entity<IdentityUserClaim<string>>().ToTable("Claim");
            builder.Entity<IdentityUserToken<string>>().ToTable("Token");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Regra_Claim");
            builder.Entity<IdentityRole>().ToTable("Regra");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
