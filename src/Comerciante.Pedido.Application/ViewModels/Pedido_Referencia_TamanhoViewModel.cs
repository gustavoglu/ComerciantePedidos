using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Pedido_Referencia_TamanhoViewModel
    {
        public Guid? Id { get; set; }

        public Guid? Id_pedido_referencia { get; set; }

        public Guid? Id_referencia_tamanho { get; set; }

        public Guid? Id_referencia_cor { get; set; }

        public int Quantidade { get; set; } = 0;
    }
}
