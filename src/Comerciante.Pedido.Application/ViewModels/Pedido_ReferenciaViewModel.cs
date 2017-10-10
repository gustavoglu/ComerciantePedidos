using System;
using System.Collections.Generic;
using System.Text;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Pedido_ReferenciaViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_referencia { get; set; }

        public int Quantidade { get; set; }

        public Guid Id_pedido { get; set; }
    }
}
