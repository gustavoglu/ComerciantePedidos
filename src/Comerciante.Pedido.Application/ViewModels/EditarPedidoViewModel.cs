using Comerciante.Pedido.Application.ViewModels.Enums;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class EditarPedidoViewModel
    {
        public PedidoViewModel Pedido { get; set; }

        public List<AddEditReferenciaViewModel> AddEditReferencias { get; set; }

        public List<string> TipoReferencias { get; set; }
    }
}
