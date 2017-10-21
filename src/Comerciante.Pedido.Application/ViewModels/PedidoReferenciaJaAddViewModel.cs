using System;
using System.Collections.Generic;
using System.Text;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class PedidoReferenciaJaAddViewModel
    {
        public PedidoViewModel Pedido { get; set; }

        public List<Pedido_ReferenciaViewModel> Pedido_Referencias  { get; set; }
    }
}
