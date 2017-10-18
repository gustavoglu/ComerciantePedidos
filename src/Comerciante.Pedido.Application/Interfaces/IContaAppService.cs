using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IContaAppService : IDisposable
    {
        ContaViewModel Criar(ContaViewModel ContaViewModel);

        IEnumerable<ContaViewModel> Criar(ICollection<ContaViewModel> ContaViewModels);

        ContaViewModel Atualizar(ContaViewModel ContaViewModel);

        int Deletar(Guid id);

        ContaViewModel TrazerPorId(Guid id);

        IEnumerable<ContaViewModel> TrazerTodos();

        IEnumerable<ContaViewModel> TrazerAtivos();

        IEnumerable<ContaViewModel> TrazerDeletados();
    }
}
