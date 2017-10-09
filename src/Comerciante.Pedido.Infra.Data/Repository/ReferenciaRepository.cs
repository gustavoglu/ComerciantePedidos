using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class ReferenciaRepository : Repository<Referencia>, IReferenciaRepository
    {
        public ReferenciaRepository(ContextPedidos db) : base(db)
        {
        }
    }
}
