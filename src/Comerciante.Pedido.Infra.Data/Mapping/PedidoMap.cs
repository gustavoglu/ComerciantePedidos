using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class PedidoMap : EntityTypeConfiguration<Domain.Models.Pedido>
    {
        public override void Map(EntityTypeBuilder<Domain.Models.Pedido> builder)
        {
            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.Id_cliente);

            builder.HasOne(p => p.Colecao)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.Id_colecao)
                .IsRequired(false);
        }
    }
}
