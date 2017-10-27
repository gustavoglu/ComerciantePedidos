using Comerciante.Pedido.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Pedido : Entity
    {
        public int Numero { get; set; }

        public double Total { get; set; }

        public Guid Id_cliente { get; set; }

        public Guid? Id_colecao { get; set; }

        public bool Finalizado { get; set; } = false;

        //Entity Framework
        public Colecao Colecao { get; set; }

        public Conta Cliente { get; set; }

        public ICollection<Pedido_Referencia> Pedido_Referencias { get; set; }
    }
}
