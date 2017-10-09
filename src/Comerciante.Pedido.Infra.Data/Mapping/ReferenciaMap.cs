using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class ReferenciaMap : EntityTypeConfiguration<Referencia>
    {
        public override void Map(EntityTypeBuilder<Referencia> builder)
        {
            
        }
    }
}
