using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface ICorAppService : IDisposable
    {
        CorViewModel Criar(CorViewModel CorViewModel);

        IEnumerable<CorViewModel> Criar(ICollection<CorViewModel> CorViewModels);

        CorViewModel Atualizar(CorViewModel CorViewModel);

        int Deletar(Guid id);

        CorViewModel TrazerPorId(Guid id);

        IEnumerable<CorViewModel> TrazerTodos();

        IEnumerable<CorViewModel> TrazerAtivos();

        IEnumerable<CorViewModel> TrazerDeletados();
    }
}
