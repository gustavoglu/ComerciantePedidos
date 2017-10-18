using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface ITamanhoAppService : IDisposable
    {
        TamanhoViewModel Criar(TamanhoViewModel TamanhoViewModel);

        IEnumerable<TamanhoViewModel> Criar(ICollection<TamanhoViewModel> TamanhoViewModels);

        TamanhoViewModel Atualizar(TamanhoViewModel TamanhoViewModel);

        int Deletar(Guid id);

        TamanhoViewModel TrazerPorId(Guid id);

        IEnumerable<TamanhoViewModel> TrazerTodos();

        IEnumerable<TamanhoViewModel> TrazerAtivos();

        IEnumerable<TamanhoViewModel> TrazerDeletados();
    }
}
