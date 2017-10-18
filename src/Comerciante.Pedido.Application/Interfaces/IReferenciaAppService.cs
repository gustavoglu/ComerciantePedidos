using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferenciaAppService : IDisposable
    {
        ReferenciaViewModel Criar(ReferenciaViewModel ReferenciaViewModel);

        IEnumerable<ReferenciaViewModel> Criar(ICollection<ReferenciaViewModel> ReferenciaViewModels);

        ReferenciaViewModel Atualizar(ReferenciaViewModel ReferenciaViewModel);

        int Deletar(Guid id);

        ReferenciaViewModel TrazerPorId(Guid id);

        IEnumerable<ReferenciaViewModel> TrazerTodos();

        IEnumerable<ReferenciaViewModel> TrazerAtivos();

        IEnumerable<ReferenciaViewModel> TrazerDeletados();
    }
}
