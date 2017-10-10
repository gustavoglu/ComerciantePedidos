using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IPedido_Referencia_TamanhoAppService : IDisposable
    {
        void Criar(Pedido_Referencia_TamanhoViewModel Pedido_Referencia_TamanhoViewModel);

        void Criar(ICollection<Pedido_Referencia_TamanhoViewModel> Pedido_Referencia_TamanhoViewModels);

        void Atualizar(Pedido_Referencia_TamanhoViewModel Pedido_Referencia_TamanhoViewModel);

        int Deletar(Guid id);

        Pedido_Referencia_TamanhoViewModel TrazerPorId(Guid id);

        IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerTodos();

        IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerAtivos();

        IEnumerable<Pedido_Referencia_TamanhoViewModel> TrazerDeletados();
    }
}
