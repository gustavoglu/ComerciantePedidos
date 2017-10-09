using Comerciante.Pedido.Domain.Core.Models;
using System;

namespace Comerciante.Pedido.Domain.Models
{
    public class Pedido_Referencia_Tamanho : Entity
    {
        public Guid Id_pedido_referencia { get; set; }

        public Guid Id_referencia_tamanho { get; set; }

        public Guid Id_referencia_cor { get; set; }

        public int Quantidade { get; set; } = 0;

        //Entity Framework
        public virtual Pedido_Referencia Pedido_Referencia { get; set; }

        public virtual Referencia_Tamanho Referencia_Tamanho { get; set; }

        public virtual Referencia_Cor Referencia_Cor { get; set; }
    }
}
