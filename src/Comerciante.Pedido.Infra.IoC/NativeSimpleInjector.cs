using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.Services;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Infra.Data.Context;
using Comerciante.Pedido.Infra.Data.Repository;
using Comerciante.Pedido.Infra.Identity.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Comerciante.Pedido.Infra.IoC
{
    public class NativeSimpleInjector
    {
        public static void RegisterDependencys(IServiceCollection services)
        {

            //AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            //Infra Data
            services.AddScoped<ContextPedidos>();
            services.AddScoped<ContextUsuario>();

            //Repository
            services.AddScoped<IColecaoRepository, ColecaoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ICorRepository, CorRepository>();
            services.AddScoped<IPedido_ReferenciaRepository, Pedido_ReferenciaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IReferencia_ColecaoRepository, Referencia_ColecaoRepository>();
            services.AddScoped<IReferencia_CorRepository, Referencia_CorRepository>();
            services.AddScoped<IReferencia_TamanhoRepository, Referencia_TamanhoRepository>();
            services.AddScoped<IReferenciaRepository, ReferenciaRepository>();

            //Services
            services.AddScoped<IColecaoAppService, ColecaoAppService>();
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<ICorAppService, CorAppService>();
            services.AddScoped<IPedido_ReferenciaAppService, Pedido_ReferenciaAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();
            services.AddScoped<IReferencia_ColecaoAppService, Referencia_ColecaoAppService>();
            services.AddScoped<IReferencia_CorAppService, Referencia_CorAppService>();
            services.AddScoped<IReferenciaAppService, ReferenciaAppService>();
            services.AddScoped<IReferencia_TamanhoAppService, Referencia_TamanhoAppService>();
            services.AddScoped<IReferenciaAppService, ReferenciaAppService>();
 
        }
    }
}
