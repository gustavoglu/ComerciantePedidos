using Comerciante.Pedido.Domain.Core.Models;
using System;

namespace Comerciante.Pedido.Domain.Models
{
    public class Referencia_Colecao : Entity
    {
        public Guid Id_referencia { get; set; }

        public Guid Id_colecao { get; set; }

        //Entity Framework
        public virtual Referencia Referencia { get; set; }

        public virtual Colecao Colecao { get; set; }
    }
}
