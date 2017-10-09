using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Pedido_ReferenciaMap : EntityTypeConfiguration<Pedido_Referencia>
    {
        public override void Map(EntityTypeBuilder<Pedido_Referencia> builder)
        {
            builder.HasOne(pr => pr.Pedido)
                .WithMany(p => p.Pedido_Referencias)
                .HasForeignKey(pr => pr.Id_pedido);

            builder.HasOne(pr => pr.Referencia)
                .WithMany(r => r.Pedido_Referencias)
                .HasForeignKey(pr => pr.Id_referencia);
        }
    }
}
