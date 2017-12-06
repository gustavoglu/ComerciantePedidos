using Comerciante.Pedido.Domain.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IReferencia_CorRepository : IRepository<Referencia_Cor>
    {
        int Deletar(IEnumerable<Referencia_Cor> referencia_Cores);
    }
}
