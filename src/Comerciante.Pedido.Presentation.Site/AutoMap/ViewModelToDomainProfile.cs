using AutoMapper;
using Comerciante.Pedido.Application.ViewModels;
using Comerciante.Pedido.Domain.Models;

namespace Comerciante.Pedido.Presentation.Site.AutoMap
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<Conta, ContaViewModel>().ReverseMap();
            CreateMap<Colecao, ColecaoViewModel>().ReverseMap();
            CreateMap<Cor, CorViewModel>().ReverseMap();
            CreateMap<Comerciante.Pedido.Domain.Models.Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Pedido_Referencia, Pedido_ReferenciaViewModel>().ReverseMap();
            CreateMap<Pedido_Referencia_Tamanho, Pedido_Referencia_TamanhoViewModel>().ReverseMap();
            CreateMap<Referencia, ReferenciaViewModel>().ReverseMap();
            CreateMap<Referencia_Colecao, Referencia_ColecaoViewModel>().ReverseMap();
            CreateMap<Referencia_Cor, Referencia_CorViewModel>().ReverseMap();
            CreateMap<Referencia_Imagem, Referencia_ImagemViewModel>().ReverseMap();
            CreateMap<Referencia_Tamanho, Referencia_TamanhoViewModel>().ReverseMap();
            CreateMap<Tamanho, TamanhoViewModel>().ReverseMap();
        }
    }
}
