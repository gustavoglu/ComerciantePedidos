using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class Referencia_TamanhoViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_referencia { get; set; }

        public Guid Id_tamanho { get; set; }

        public double? Total { get; set; } = 0;

        public TamanhoViewModel Tamanho  { get; set; }
    }
}
