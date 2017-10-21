using System.Collections.Generic;
using System.Linq;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class AddEditReferenciaViewModel
    {
        public AddEditReferenciaViewModel(ReferenciaViewModel referencia)
        {
            Referencia = referencia;
            Cores = (from referencia_cor in referencia.Referencia_Cores
                    select new CorReferenciaViewModel { Id_referencia_cor = referencia_cor.Id, Id = referencia_cor.Id_cor, Descricao = referencia_cor.Cor.Descricao }).ToList();
            Tamanhos = ( from referencia_tamanho in referencia.Referencia_Tamanhos
                         select new TamanhoReferenciaViewModel { Id = referencia_tamanho.Id_tamanho, Id_referencia_tamanho = referencia_tamanho.Id, Descricao = referencia_tamanho.Tamanho.Descricao }
                        ).ToList();
        }

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

        public List<CorReferenciaViewModel> Cores { get; set; }

        public List<TamanhoReferenciaViewModel> Tamanhos { get; set; }
    }
}
