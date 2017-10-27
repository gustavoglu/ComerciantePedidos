using Comerciante.Pedido.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IPedidoAppService : IDisposable
    {
        PedidoViewModel Criar(PedidoViewModel PedidoViewModel);

        IEnumerable<PedidoViewModel> Criar(ICollection<PedidoViewModel> PedidoViewModels);

        PedidoViewModel Atualizar(PedidoViewModel PedidoViewModel);

        int Deletar(Guid id);

        PedidoViewModel TrazerPorId(Guid id);

        IEnumerable<PedidoViewModel> TrazerTodos();

        IEnumerable<PedidoViewModel> TrazerAtivos();

        IEnumerable<PedidoViewModel> TrazerDeletados();

        int NovoNumero();

        TotalPedidoViewModel TrazerTotais(Guid id);

        PedidoViewModel Finalizar(Guid id_pedido);

        PedidoViewModel Reabrir(Guid id_pedido);
    }
}
