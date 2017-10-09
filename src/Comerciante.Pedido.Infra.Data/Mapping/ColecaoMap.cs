using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comerciante.Pedido.Infra.Data.Mapping
{
    public class ColecaoMap : EntityTypeConfiguration<Colecao>
    {
        public override void Map(EntityTypeBuilder<Colecao> builder)
        {
        }
    }
}
