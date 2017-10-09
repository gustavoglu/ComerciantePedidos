using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Comerciante.Pedido.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Comerciante.Pedido.Infra.Data.Context
{
    public class ContextPedidos : DbContext
    {
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Pedido_Referencia_Tamanho> Pedido_Referencia_Tamanhos { get; set; }
        public DbSet<Pedido_Referencia> Pedido_Referencias { get; set; }
        public DbSet<Domain.Models.Pedido> Pedidos{ get; set; }
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
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
