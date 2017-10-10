using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Pedido_Referencia_TamanhoMap : EntityTypeConfiguration<Pedido_Referencia_Tamanho>
    {
        public override void Map(EntityTypeBuilder<Pedido_Referencia_Tamanho> builder)
        {
            builder.HasOne(prt => prt.Pedido_Referencia)
                .WithMany(pr => pr.Pedido_Referencia_Tamanhos)
                .HasForeignKey(prt => prt.Id_pedido_referencia);

            builder.HasOne(prt => prt.Referencia_Tamanho)
                .WithMany(rt => rt.Pedido_Referencia_Tamanhos)
                .HasForeignKey(prt => prt.Id_referencia_tamanho)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(prt => prt.Referencia_Cor)
             .WithMany(rc => rc.Pedido_Referencia_Tamanhos)
             .HasForeignKey(prt => prt.Id_referencia_cor)
             .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);



        }
    }
}
