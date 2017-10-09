using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Referencia_ColecaoRepository : Repository<Referencia_Colecao>, IReferencia_ColecaoRepository
    {
        public Referencia_ColecaoRepository(ContextPedidos context) : base(context)
        {

        }
    }
}
