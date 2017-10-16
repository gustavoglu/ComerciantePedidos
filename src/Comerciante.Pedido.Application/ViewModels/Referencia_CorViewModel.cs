using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Referencia_CorViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_referencia { get; set; }

        public Guid Id_cor { get; set; }

        public double? Preco { get; set; } = 0;

        public CorViewModel Cor  { get; set; }
    }
}
