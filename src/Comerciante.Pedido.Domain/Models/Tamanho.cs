using Comerciante.Pedido.Domain.Core.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Tamanho : Entity
    {
        public string Descricao { get; set; }

        //Entity Framework
        public virtual ICollection<Referencia_Tamanho> Referencia_Tamanhos { get; set; }
    }
}
