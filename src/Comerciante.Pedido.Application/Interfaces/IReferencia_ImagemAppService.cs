using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IReferencia_ImagemAppService : IDisposable
    {
        Referencia_ImagemViewModel Criar(Referencia_ImagemViewModel Referencia_ImagemViewModel);

        IEnumerable<Referencia_ImagemViewModel> Criar(ICollection<Referencia_ImagemViewModel> Referencia_ImagemViewModel);

        Referencia_ImagemViewModel Atualizar(Referencia_ImagemViewModel Referencia_ImagemViewModel);

        int Deletar(Guid id);

        Referencia_ImagemViewModel TrazerPorId(Guid id);

        IEnumerable<Referencia_ImagemViewModel> TrazerTodos();

        IEnumerable<Referencia_ImagemViewModel> TrazerAtivos();

        IEnumerable<Referencia_ImagemViewModel> TrazerDeletados();
    }
}
