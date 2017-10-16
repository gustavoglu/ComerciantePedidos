using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class AddEditReferenciaViewModel
    {
        public ReferenciaViewModel Referencia { get; set; }

        public List<Pedido_Referencia_TamanhoViewModel> Pedido_Referencia_Tamanhos
        {
            get
            {
                var pedido_referencia_tamanhos = new List<Pedido_Referencia_TamanhoViewModel>();

                foreach (var cor in Referencia.Referencia_Cores)
                {
                    foreach (var tamanho in Referencia.Referencia_Tamanhos)
                    {
                        pedido_referencia_tamanhos.Add(new Pedido_Referencia_TamanhoViewModel
                        {
                            Quantidade = 0,
                            Id_referencia_tamanho = tamanho.Id,
                            Id_referencia_cor = cor.Id
                        });
                    }
                }
                return pedido_referencia_tamanhos;
            }
        }

        public List<CorViewModel> Cores { get { return Referencia.Referencia_Cores.Select(c => c.Cor).ToList(); } }

        public List<TamanhoViewModel> Tamanhos { get { return Referencia.Referencia_Tamanhos.Select(t => t.Tamanho).ToList(); } }
    }
}
