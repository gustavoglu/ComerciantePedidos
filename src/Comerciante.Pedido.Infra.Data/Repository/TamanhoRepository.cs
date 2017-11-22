using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class TamanhoRepository : Repository<Tamanho>, ITamanhoRepository
    {
        public TamanhoRepository(ContextPedidos db) : base(db)
        {
        }
    }
}
