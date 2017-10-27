using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class Pedido_ReferenciaRepository : Repository<Pedido_Referencia>, IPedido_ReferenciaRepository
    {
        public Pedido_ReferenciaRepository(ContextPedidos context) : base(context)
        {

        }

        public override int Deletar(Guid id)
        {
            var obj = DbSet.
                Include(pr => pr.Pedido_Referencia_Tamanhos)
                .FirstOrDefault(pr => pr.Id == id);

            DbSet.Remove(obj);
            return this.Save();
        }

        public override IEnumerable<Pedido_Referencia> TrazerAtivos()
        {
            return DbSet
                .Include(pr => pr.Referencia)
                .Where(pr => pr.Deletado == false);
        }
        public override IEnumerable<Pedido_Referencia> PesquisarAtivos(Expression<Func<Pedido_Referencia, bool>> predicate)
        {
            return DbSet.Include(pr => pr.Referencia)
                .Where(pr => pr.Deletado == false)
                .Where(predicate);
        }


        public IEnumerable<Pedido_Referencia> TrazerAtivosIncludePedido_Referencia_TamanhosPorPedido(Guid id_pedido)
        {
            return DbSet.Where(pr => pr.Deletado == false && pr.Id_pedido == id_pedido)
                .Include(pr => pr.Pedido_Referencia_Tamanhos);
        }

        public async Task<IEnumerable<Pedido_Referencia>> TrazerAtivosPorPedidoAllInclude(Guid id_pedido)
        {
            return await DbSet.AsNoTracking()
                .Include(pr => pr.Referencia)
                .Include(pr => pr.Pedido_Referencia_Tamanhos)
                    .ThenInclude(pr => pr.Referencia_Cor)
                    .ThenInclude(pr => pr.Cor)
                .Include(pr => pr.Pedido_Referencia_Tamanhos)
                    .ThenInclude(pr => pr.Referencia_Tamanho)
                    .ThenInclude(pr => pr.Tamanho)
                .Where(pr => pr.Deletado == false && pr.Id_pedido == id_pedido).ToListAsync();
        }
    }
}
