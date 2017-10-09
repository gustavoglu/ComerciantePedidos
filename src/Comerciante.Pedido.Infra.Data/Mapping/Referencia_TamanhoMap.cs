using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class Referencia_TamanhoMap : EntityTypeConfiguration<Referencia_Tamanho>
    {
        public override void Map(EntityTypeBuilder<Referencia_Tamanho> builder)
        {
            builder.HasOne(rt => rt.Referencia)
                .WithMany(r => r.Referencia_Tamanhos)
                .HasForeignKey(rt => rt.Id_referencia);

            builder.HasOne(rt => rt.Tamanho)
                .WithMany(r => r.Referencia_Tamanhos)
                .HasForeignKey(rt => rt.Id_tamanho);
        }
    }
}
