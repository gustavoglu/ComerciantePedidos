using Comerciante.Pedido.Domain.Core.Models;
using System;

namespace Comerciante.Pedido.Domain.Models
{
    public class Referencia_Imagem : Entity
    {
        public string Uri { get; set; }

        public Guid Id_referencia { get; set; }

        //Entity Framework

        public virtual Referencia Referencia { get; set; }
    }
}
