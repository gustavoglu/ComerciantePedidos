using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
   public interface IReferencia_TamanhoAppService : IDisposable
    {
        Referencia_TamanhoViewModel Criar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel);

        IEnumerable<Referencia_TamanhoViewModel> Criar(ICollection<Referencia_TamanhoViewModel> Referencia_TamanhoViewModels);

        Referencia_TamanhoViewModel Atualizar(Referencia_TamanhoViewModel Referencia_TamanhoViewModel);

        int Deletar(Guid id);

        Referencia_TamanhoViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_TamanhoViewModel> TrazerTodos();

        IEnumerable<Referencia_TamanhoViewModel> TrazerAtivos();

        IEnumerable<Referencia_TamanhoViewModel> TrazerDeletados();
    }
}
