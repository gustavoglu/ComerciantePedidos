using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Domain.Models.Pedido> ,IPedidoRepository
    {
        public PedidoRepository(ContextPedidos context) : base (context)
        {

        }
    }
}
