using System;
using System.Collections.Generic;
using Comerciante.Pedido.Application.ViewModels;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferencia_ColecaoAppService : IDisposable
    {
        void Criar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel);

        void Criar(ICollection<Referencia_ColecaoViewModel> Referencia_ColecaoViewModels);

        void Atualizar(Referencia_ColecaoViewModel Referencia_ColecaoViewModel);

        int Deletar(Guid id);

        Referencia_ColecaoViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_ColecaoViewModel> TrazerTodos();

        IEnumerable<Referencia_ColecaoViewModel> TrazerAtivos();

        IEnumerable<Referencia_ColecaoViewModel> TrazerDeletados();
    }
}
