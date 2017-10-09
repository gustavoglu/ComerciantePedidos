using Comerciante.Pedido.Domain.Core.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Conta : Entity
    {
        public string Nome { get; set; }


        //Entity Framework
        public virtual IEnumerable<Pedido> Pedidos { get; set; }

    }
}
