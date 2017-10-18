using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IColecaoAppService : IDisposable
    {
        ColecaoViewModel Criar(ColecaoViewModel ContaViewModel);

        IEnumerable<ColecaoViewModel> Criar(ICollection<ColecaoViewModel> ContaViewModels);

        ColecaoViewModel Atualizar(ColecaoViewModel ContaViewModel);

        int Deletar(Guid id);

        ColecaoViewModel TrazerPorId(Guid id);

        IEnumerable<ColecaoViewModel> TrazerTodos();

        IEnumerable<ColecaoViewModel> TrazerAtivos();

        IEnumerable<ColecaoViewModel> TrazerDeletados();
    }
}
