using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Referencia_ImagemMap : EntityTypeConfiguration<Referencia_Imagem>
    {
        public override void Map(EntityTypeBuilder<Referencia_Imagem> builder)
        {
            builder.HasOne(ri => ri.Referencia)
                .WithMany(r => r.Referencia_Imagens)
                .HasForeignKey(ri => ri.Id_referencia);
        }
    }
}
