using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IColecaoAppService : IDisposable
    {
        void Criar(ColecaoViewModel ContaViewModel);

        void Criar(ICollection<ColecaoViewModel> ContaViewModels);

        void Atualizar(ColecaoViewModel ContaViewModel);

        int Deletar(Guid id);

        ColecaoViewModel TrazerPorId(Guid id);

        IEnumerable<ColecaoViewModel> TrazerTodos();

        IEnumerable<ColecaoViewModel> TrazerAtivos();

        IEnumerable<ColecaoViewModel> TrazerDeletados();
    }
}
