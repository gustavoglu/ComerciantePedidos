using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Pedido_ReferenciaRepository : Repository<Pedido_Referencia>, IPedido_ReferenciaRepository
    {
        public Pedido_ReferenciaRepository(ContextPedidos context) : base(context)
        {

        }
    }
}
