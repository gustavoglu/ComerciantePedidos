using Comerciante.Pedido.Domain.Core.Models;
using System.Collections.Generic;

namespace Comerciante.Pedido.Domain.Models
{
    public class Referencia : Entity
    {
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public bool Grade { get; set; }

        //Entity Framework
        public virtual ICollection<Referencia_Colecao> Referencia_Colecoes { get; set; }

        public virtual ICollection<Pedido_Referencia> Pedido_Referencias { get; set; }

        public virtual ICollection<Referencia_Tamanho> Referencia_Tamanhos { get; set; }

        public virtual ICollection<Referencia_Cor> Referencia_Cores { get; set; }

        public virtual ICollection<Referencia_Imagem> Referencia_Imagens { get; set; }
    }
}
