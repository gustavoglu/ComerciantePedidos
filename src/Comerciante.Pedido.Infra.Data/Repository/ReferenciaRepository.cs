using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class ReferenciaRepository : Repository<Referencia>, IReferenciaRepository
    {
        public ReferenciaRepository(ContextPedidos db) : base(db)
        {
        }

        public override IEnumerable<Referencia> TrazerAtivos()
        {
            return DbSet
                .Include(r => r.Referencia_Cores)
                    .ThenInclude(rc => rc.Cor)
                .Include(r => r.Referencia_Tamanhos)
                    .ThenInclude(rt => rt.Tamanho)
                .Include(r => r.Referencia_Imagens)
                .Where(r => r.Deletado == false);
        }

        public override Referencia TrazerPorId(Guid id)
        {
            return DbSet
                .Include(r => r.Referencia_Cores)
                    .ThenInclude(rc => rc.Cor)
                .Include(r => r.Referencia_Tamanhos)
                    .ThenInclude(rt => rt.Tamanho)
                .Include(r => r.Referencia_Imagens)
                .FirstOrDefault(r => r.Deletado == false && r.Id == id);
        }
    }
}
