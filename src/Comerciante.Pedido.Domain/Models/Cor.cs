using Comerciante.Pedido.Domain.Core.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Cor : Entity
    {
        public string Descricao { get; set; }

        //Entity Framework
        public virtual ICollection<Referencia_Cor> Referencia_Cores { get; set; }



    }
}
