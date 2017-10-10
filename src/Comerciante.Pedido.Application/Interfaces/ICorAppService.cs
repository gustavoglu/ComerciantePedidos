using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface ICorAppService : IDisposable
    {
        void Criar(CorViewModel CorViewModel);

        void Criar(ICollection<CorViewModel> CorViewModels);

        void Atualizar(CorViewModel CorViewModel);

        int Deletar(Guid id);

        CorViewModel TrazerPorId(Guid id);

        IEnumerable<CorViewModel> TrazerTodos();

        IEnumerable<CorViewModel> TrazerAtivos();

        IEnumerable<CorViewModel> TrazerDeletados();
    }
}
