using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Referencia_CorRepository : Repository<Referencia_Cor>, IReferencia_CorRepository
    {
        public Referencia_CorRepository(ContextPedidos context) : base(context)
        {

        }

        public int Deletar(IEnumerable<Referencia_Cor> referencia_Cores)
        {
            foreach (var referencia_cor in referencia_Cores)
                this.DbSet.Remove(this.DbSet.Find(referencia_cor.Id.Value));

            return Save();
        }
    }
}
