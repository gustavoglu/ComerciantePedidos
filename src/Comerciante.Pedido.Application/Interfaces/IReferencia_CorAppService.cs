using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferencia_CorAppService : IDisposable
    {
        void Criar(Referencia_CorViewModel Referencia_CorViewModel);

        void Criar(ICollection<Referencia_CorViewModel> Referencia_CorViewModels);

        void Atualizar(Referencia_CorViewModel Referencia_CorViewModel);

        int Deletar(Guid id);

        Referencia_CorViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_CorViewModel> TrazerTodos();

        IEnumerable<Referencia_CorViewModel> TrazerAtivos();

        IEnumerable<Referencia_CorViewModel> TrazerDeletados();
    }
}
