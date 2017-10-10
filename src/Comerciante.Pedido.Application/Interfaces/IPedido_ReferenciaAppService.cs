using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IPedido_ReferenciaAppService : IDisposable
    {
        void Criar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel);

        void Criar(ICollection<Pedido_ReferenciaViewModel> Pedido_ReferenciaViewModels);

        void Atualizar(Pedido_ReferenciaViewModel Pedido_ReferenciaViewModel);

        int Deletar(Guid id);

        Pedido_ReferenciaViewModel TrazerPorId(Guid id);

        IEnumerable<Pedido_ReferenciaViewModel> TrazerTodos();

        IEnumerable<Pedido_ReferenciaViewModel> TrazerAtivos();

        IEnumerable<Pedido_ReferenciaViewModel> TrazerDeletados();
    }
}
