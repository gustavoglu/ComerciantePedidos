using Comerciante.Pedido.Domain.Core.Models;
using System;

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

    }
}
