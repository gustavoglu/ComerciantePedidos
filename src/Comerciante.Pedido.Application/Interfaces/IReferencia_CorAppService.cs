using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferencia_CorAppService : IDisposable
    {
        Referencia_CorViewModel Criar(Referencia_CorViewModel Referencia_CorViewModel);

        IEnumerable<Referencia_CorViewModel> Criar(ICollection<Referencia_CorViewModel> Referencia_CorViewModels);

        Referencia_CorViewModel Atualizar(Referencia_CorViewModel Referencia_CorViewModel);

        int Deletar(Guid id);

        int Deletar(IEnumerable<Referencia_CorViewModel> id);

        Referencia_CorViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_CorViewModel> TrazerTodos();

        IEnumerable<Referencia_CorViewModel> TrazerAtivos();

        IEnumerable<Referencia_CorViewModel> TrazerPorReferencia(Guid id_referencia);

        IEnumerable<Referencia_CorViewModel> TrazerDeletados();
    }
}
