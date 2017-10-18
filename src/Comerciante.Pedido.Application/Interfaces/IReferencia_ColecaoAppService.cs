using System;
using System.Collections.Generic;
using Comerciante.Pedido.Application.ViewModels;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferencia_ColecaoAppService : IDisposable
    {
        Referencia_ColecaoViewModel Criar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel);

        IEnumerable<Referencia_ColecaoViewModel> Criar(ICollection<Referencia_ColecaoViewModel> Referencia_ColecaoViewModels);

        Referencia_ColecaoViewModel Atualizar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel);

        int Deletar(Guid id);

        Referencia_ColecaoViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_ColecaoViewModel> TrazerTodos();

        IEnumerable<Referencia_ColecaoViewModel> TrazerAtivos();

        IEnumerable<Referencia_ColecaoViewModel> TrazerDeletados();
    }
}
