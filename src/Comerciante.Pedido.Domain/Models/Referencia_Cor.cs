using Comerciante.Pedido.Domain.Core.Models;
using System;

namespace Comerciante.Pedido.Domain.Models
{
    public class Referencia_Cor : Entity
    {
        public Guid Id_referencia { get; set; }

        public Guid Id_cor { get; set; }

        public double? Preco { get; set; } = 0;

        //Entity Frameowkr
        public virtual Referencia Referencia { get; set; }

        public virtual Cor Cor { get; set; }
    }
}
