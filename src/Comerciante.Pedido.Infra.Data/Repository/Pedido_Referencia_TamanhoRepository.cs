using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using System.Linq;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Pedido_Referencia_TamanhoRepository : Repository<Pedido_Referencia_Tamanho>, IPedido_Referencia_TamanhoRepository
    {
        public Pedido_Referencia_TamanhoRepository(ContextPedidos db) : base(db)
        {
        }

        public int Deletar(IEnumerable<Pedido_Referencia_Tamanho> pedido_Referencia_Tamanhos)
        {
            foreach (var pedido_Referencia_Tamanho in pedido_Referencia_Tamanhos)
            {
                DbSet.Remove(pedido_Referencia_Tamanho);
            }

            return Save();
        }
    }
}
