using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class CorRepository : Repository<Cor>, ICorRepository
    {
        public CorRepository(ContextPedidos context) : base(context)
        {

        }
    }
}
