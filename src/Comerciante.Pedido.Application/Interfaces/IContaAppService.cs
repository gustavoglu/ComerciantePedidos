using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IContaAppService : IDisposable
    {
        void Criar(ContaViewModel ContaViewModel);

        void Criar(ICollection<ContaViewModel> ContaViewModels);

        void Atualizar(ContaViewModel ContaViewModel);

        int Deletar(Guid id);

        ContaViewModel TrazerPorId(Guid id);

        IEnumerable<ContaViewModel> TrazerTodos();

        IEnumerable<ContaViewModel> TrazerAtivos();

        IEnumerable<ContaViewModel> TrazerDeletados();
    }
}
