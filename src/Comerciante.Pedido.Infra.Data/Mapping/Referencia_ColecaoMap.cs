using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Referencia_ColecaoMap : EntityTypeConfiguration<Referencia_Colecao>
    {
        public override void Map(EntityTypeBuilder<Referencia_Colecao> builder)
        {
            builder.HasOne(rc => rc.Referencia)
                .WithMany(r => r.Referencia_Colecoes)
                .HasForeignKey(rc => rc.Id_referencia);

            builder.HasOne(rc => rc.Colecao)
                .WithMany(c => c.Referencia_Colecoes)
                .HasForeignKey(rc => rc.Id_colecao);

        }
    }
}
