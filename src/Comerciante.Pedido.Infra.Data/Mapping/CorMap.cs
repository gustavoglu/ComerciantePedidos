using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class CorMap : EntityTypeConfiguration<Cor>
    {
        public override void Map(EntityTypeBuilder<Cor> builder)
        {
           
        }
    }
}
