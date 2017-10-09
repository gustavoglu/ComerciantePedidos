using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comerciante.Pedido.Domain.Models
{
    public class Colecao : Entity
    {
        public string Descricao { get; set; }

        //Entity Framework
        public virtual ICollection<Referencia_Colecao> Referencia_Colecoes { get; set; }

        public virtual ICollection<Pedido> Pedidos  { get; set; }

    }
}
