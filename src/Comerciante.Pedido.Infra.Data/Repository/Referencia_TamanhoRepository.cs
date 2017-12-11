using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Referencia_TamanhoRepository : Repository<Referencia_Tamanho>,IReferencia_TamanhoRepository
    {
        public Referencia_TamanhoRepository(ContextPedidos context) : base(context)
        {

        }

        public int Deletar(IEnumerable<Referencia_Tamanho> referencia_tamanhos)
        {
            foreach (var referencia_tamanho in referencia_tamanhos)
                DbSet.Remove(this.DbSet.Find(referencia_tamanho.Id.Value));

            return Save();
        }
    }
}
