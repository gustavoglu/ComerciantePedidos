using Comerciante.Pedido.Domain.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Interfaces.Repository
{
    public interface IReferencia_TamanhoRepository : IRepository<Referencia_Tamanho>
    {
        int Deletar(IEnumerable<Referencia_Tamanho> referencia_tamanhos);
    }

    
}
