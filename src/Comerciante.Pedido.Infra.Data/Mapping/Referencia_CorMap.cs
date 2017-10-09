using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Referencia_CorMap : EntityTypeConfiguration<Referencia_Cor>
    {
        public override void Map(EntityTypeBuilder<Referencia_Cor> builder)
        {
            builder.HasOne(rc => rc.Referencia)
                .WithMany(r => r.Referencia_Cores)
                .HasForeignKey(rc => rc.Id_referencia);

            builder.HasOne(rc => rc.Cor)
               .WithMany(r => r.Referencia_Cores)
               .HasForeignKey(rc => rc.Id_cor);
        }
    }
}
