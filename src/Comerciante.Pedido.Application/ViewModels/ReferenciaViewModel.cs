using System;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class ReferenciaViewModel
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public string ImgUri { get; set; }

        public bool Grade { get; set; }
    }
}
