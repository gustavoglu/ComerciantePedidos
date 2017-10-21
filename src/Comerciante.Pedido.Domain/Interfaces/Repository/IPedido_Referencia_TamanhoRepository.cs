using Comerciante.Pedido.Domain.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IPedido_Referencia_TamanhoRepository : IRepository<Pedido_Referencia_Tamanho>
    {

        int Deletar(IEnumerable<Pedido_Referencia_Tamanho> pedido_Referencia_Tamanhos);
    }
}
