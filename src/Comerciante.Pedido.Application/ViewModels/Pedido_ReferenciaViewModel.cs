using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Pedido_ReferenciaViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_referencia { get; set; }

        public int Quantidade { get; set; }

        public Guid Id_pedido { get; set; }

        public double Total { get; set; } = 0;
    }
}
