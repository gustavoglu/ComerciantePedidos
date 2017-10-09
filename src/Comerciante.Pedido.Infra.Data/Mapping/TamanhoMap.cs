using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class TamanhoMap : EntityTypeConfiguration<Tamanho>
    {
        public override void Map(EntityTypeBuilder<Tamanho> builder)
        {
            
        }
    }
}
