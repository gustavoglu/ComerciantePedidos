using Comerciante.Pedido.Domain.Core.Models;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Comerciante.Pedido.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Comerciante.Pedido.Infra.Data.Context
{
    public class ContextPedidos : DbContext
    {
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Pedido_Referencia_Tamanho> Pedido_Referencia_Tamanhos { get; set; }
        public DbSet<Pedido_Referencia> Pedido_Referencias { get; set; }
        public DbSet<Domain.Models.Pedido> Pedidos { get; set; }
        public DbSet<Referencia_Colecao> Referencia_Colecoes { get; set; }
        public DbSet<Referencia_Cor> Referencia_Cores { get; set; }
        public DbSet<Referencia_Tamanho> Referencia_Tamanhos { get; set; }
        public DbSet<Referencia> Referencias { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new ColecaoMap());
            modelBuilder.AddConfiguration(new ContaMap());
            modelBuilder.AddConfiguration(new CorMap());
            modelBuilder.AddConfiguration(new Pedido_Referencia_TamanhoMap());
            modelBuilder.AddConfiguration(new Pedido_ReferenciaMap());
            modelBuilder.AddConfiguration(new PedidoMap());
            modelBuilder.AddConfiguration(new Referencia_ColecaoMap());
            modelBuilder.AddConfiguration(new Referencia_CorMap());
            modelBuilder.AddConfiguration(new Referencia_TamanhoMap());
            modelBuilder.AddConfiguration(new ReferenciaMap());
            modelBuilder.AddConfiguration(new TamanhoMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public override int SaveChanges()
        {
            var adicionados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Added);
            var atualizados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Modified);
            var deletados = ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Deleted);

            if (adicionados.Any())
                AdicionaEntitys(adicionados);

            if (atualizados.Any())
                AtualizaEntitys(atualizados);

            if (deletados.Any())
                DeletaEntitys(deletados);

            return base.SaveChanges();
        }

        private void AdicionaEntitys(IEnumerable<EntityEntry> adicionados)
        {
            foreach (var entityEntry in adicionados)
            {
                Entity entity = ((Entity)entityEntry.Entity);
                entity.CriadoEm = DateTime.Now;
            }
        }

        private void AtualizaEntitys(IEnumerable<EntityEntry> atualizados)
        {
            foreach (var entityEntry in atualizados)
            {
                Entity entity = ((Entity)entityEntry.Entity);
                entity.AtualizadoEm = DateTime.Now;
            }
        }

        private void DeletaEntitys(IEnumerable<EntityEntry> deletados)
        {
            foreach (var entityEntry in deletados)
            {
                Entity entity = ((Entity)entityEntry.Entity);
                entity.DeletadoEm = DateTime.Now;
            }
        }

    }
}
