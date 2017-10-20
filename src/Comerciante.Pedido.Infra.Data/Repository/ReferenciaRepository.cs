using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class ReferenciaRepository : Repository<Referencia>, IReferenciaRepository
    {
        public ReferenciaRepository(ContextPedidos db) : base(db)
        {
        }

        public override IEnumerable<Referencia> TrazerAtivos()
        {
            var list = this.DbSet
                .Include(r => r.Referencia_Cores)
                .Include(r => r.Referencia_Tamanhos)
                .Include(r => r.Referencia_Imagens)
                .Where(r => r.Deletado == false);

            return list;
        }
    }
}
