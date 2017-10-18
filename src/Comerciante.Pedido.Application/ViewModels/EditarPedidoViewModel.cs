using System.Collections.Generic;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class EditarPedidoViewModel
    {
        public PedidoViewModel Pedido { get; set; }

        public List<AddEditReferenciaViewModel> AddEditReferencias { get; set; }
    }
}
