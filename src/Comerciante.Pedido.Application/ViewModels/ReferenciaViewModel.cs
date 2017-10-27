using Comerciante.Pedido.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comerciante.Pedido.Application.ViewModels
{
    public class ReferenciaViewModel
    {
        public ReferenciaViewModel()
        {
            Referencia_Tamanhos = new List<Referencia_TamanhoViewModel>();
            Referencia_Cores = new List<Referencia_CorViewModel>();
            Referencia_Imagens = new List<Referencia_ImagemViewModel>();
        }

        public Guid? Id { get; set; }

        [Display(Name = "Ref")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name ="Preço")]
        public double Preco { get; set; }

        public string ImgUri { get; set; }

        public bool Grade { get; set; }

        public TipoReferenciaViewModel? Tipo { get; set; } = TipoReferenciaViewModel.Outros;

        public virtual ICollection<Referencia_TamanhoViewModel> Referencia_Tamanhos { get; set; }

        public virtual ICollection<Referencia_CorViewModel> Referencia_Cores { get; set; }

        public virtual ICollection<Referencia_ImagemViewModel> Referencia_Imagens { get; set; }
    }
}
