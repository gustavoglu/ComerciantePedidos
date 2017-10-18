using System;
using System.Collections.Generic;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Domain.Models;
using Comerciante.Pedido.Infra.Data.Context;
using Comerciante.Pedido.Domain.Interfaces;
using System.Linq;

namespace Comerciante.Pedido.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Domain.Models.Pedido>, IPedidoRepository
    {
        private readonly IUser _user;

        public PedidoRepository(ContextPedidos context, IUser user) : base(context)
        {
            _user = user;
        }

        public override IEnumerable<Domain.Models.Pedido> TrazerAtivos()
        {
            if (_user.IsAuthenticated())
                return this.DbSet.Where(p => p.Id_cliente == Guid.Parse(_user.UserId) && p.Deletado == false);

            return base.TrazerAtivos();
        }

        public override IEnumerable<Domain.Models.Pedido> TrazerDeletados()
        {
            if (_user.IsAuthenticated())
                return this.DbSet.Where(p => p.Id_cliente == Guid.Parse(_user.UserId) && p.Deletado == true);

            return base.TrazerDeletados();
        }

        public override Domain.Models.Pedido TrazerPorId(Guid id)
        {
            if (_user.IsAuthenticated())
                return this.DbSet.FirstOrDefault(p => p.Id_cliente == Guid.Parse(_user.UserId) && p.Id == id);
            return base.TrazerPorId(id);
        }

        public override IEnumerable<Domain.Models.Pedido> TrazerTodos()
        {
            if (_user.IsAuthenticated())
                return this.DbSet.Where(p => p.Id_cliente == Guid.Parse(_user.UserId));

            return base.TrazerTodos();
        }

    }
}
