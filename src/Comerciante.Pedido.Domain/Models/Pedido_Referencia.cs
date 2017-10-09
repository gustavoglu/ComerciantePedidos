using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Pedido_Referencia : Entity
    {
        public Guid Id_referencia { get; set; }

        public int Quantidade { get; set; }

        public Guid Id_pedido { get; set; }

        //Entity Framework
        public virtual Referencia Referencia { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual ICollection<Pedido_Referencia_Tamanho> Pedido_Referencia_Tamanhos { get; set; }
    }
}
