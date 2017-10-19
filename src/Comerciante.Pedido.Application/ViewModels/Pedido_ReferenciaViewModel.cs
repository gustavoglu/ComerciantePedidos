using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Pedido_ReferenciaViewModel
    {
        public Pedido_ReferenciaViewModel()
        {
            Pedido_Referencia_Tamanhos = new List<Pedido_Referencia_TamanhoViewModel>();
        }
        public Guid? Id { get; set; }

        public Guid? Id_referencia { get; set; }

        public int Quantidade { get; set; }

        public Guid? Id_pedido { get; set; }

        public double Total { get; set; } = 0;

        public virtual ICollection<Pedido_Referencia_TamanhoViewModel> Pedido_Referencia_Tamanhos { get; set; }
    }
}
