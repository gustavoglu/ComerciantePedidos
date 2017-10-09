using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Referencia_Tamanho : Entity
    {
        public Guid Id_referencia { get; set; }

        public Guid Id_tamanho { get; set; }

        public double? Total { get; set; } = 0;

        //Entity Framework
        public virtual Referencia Referencia { get; set; }

        public virtual Tamanho Tamanho { get; set; }

        public virtual ICollection<Pedido_Referencia_Tamanho> Pedido_Referencia_Tamanhos { get; set; }

    }
}
