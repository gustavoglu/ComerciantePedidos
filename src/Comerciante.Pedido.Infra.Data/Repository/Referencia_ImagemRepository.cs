using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Referencia_ImagemRepository : Repository<Referencia_Imagem>, IReferencia_ImagemRepository
    {
        public Referencia_ImagemRepository(ContextPedidos context) : base(context)
        {

        }
    }
}
