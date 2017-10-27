using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Domain.Models.Enums;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IReferenciaRepository : IRepository<Referencia>
    {
        IEnumerable<Referencia> TrazerAtivoPorTipo(TipoReferencia tipo);
    }
}
