using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class PedidoViewModel
    {
        public Guid? Id { get; set; }

        public int Numero { get; set; }

        public double Total { get; set; }

        public Guid? Id_cliente { get; set; }

        public Guid? Id_colecao { get; set; }
    }
}
