using Comerciante.Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IPedido_ReferenciaRepository : IRepository<Pedido_Referencia>
    {
        IEnumerable<Pedido_Referencia> TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(Guid id_pedido);

        Task<IEnumerable<Pedido_Referencia>> TrazerAtivosPorPedidoAllInclude(Guid id_pedido);

    }
}
