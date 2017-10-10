using AutoMapper;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Models;

namespace Comerciante.Pedido.Presentation.Site.AutoMap
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Colecao, ColecaoViewModel>();
            CreateMap<Cor, CorViewModel>();
            CreateMap<Comerciante.Pedido.Domain.Models.Pedido, PedidoViewModel>();
            CreateMap<Pedido_Referencia, Pedido_ReferenciaViewModel>();
            CreateMap<Pedido_Referencia_Tamanho, Pedido_Referencia_TamanhoViewModel>();
            CreateMap<Referencia, ReferenciaViewModel>();
            CreateMap<Referencia_Colecao, Referencia_ColecaoViewModel>();
            CreateMap<Referencia_Cor, Referencia_CorViewModel>();
            CreateMap<Referencia_Imagem, Referencia_ImagemViewModel>();
            CreateMap<Referencia_Tamanho, Referencia_TamanhoViewModel>();
            CreateMap<Tamanho, TamanhoViewModel>();
        }
    }
}
