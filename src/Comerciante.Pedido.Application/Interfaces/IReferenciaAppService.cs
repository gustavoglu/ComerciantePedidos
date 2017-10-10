using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferenciaAppService : IDisposable
    {
        void Criar(ReferenciaViewModel ReferenciaViewModel);

        void Criar(ICollection<ReferenciaViewModel> ReferenciaViewModels);

        void Atualizar(ReferenciaViewModel ReferenciaViewModel);

        int Deletar(Guid id);

        ReferenciaViewModel TrazerPorId(Guid id);

        IEnumerable<ReferenciaViewModel> TrazerTodos();

        IEnumerable<ReferenciaViewModel> TrazerAtivos();

        IEnumerable<ReferenciaViewModel> TrazerDeletados();
    }
}
