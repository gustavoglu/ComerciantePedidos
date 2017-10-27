using AutoMapper;
using Comerciante.Pedido.Application.Interfaces;
using Comerciante.Pedido.Application.Services;
using Comerciante.Pedido.Domain.Interfaces;
using Comerciante.Pedido.Domain.Interfaces.Repository;
using Comerciante.Pedido.Infra.Data.Context;
using Comerciante.Pedido.Infra.Data.Repository;
using Comerciante.Pedido.Infra.Identity.Context;
using Comerciante.Pedido.Infra.Identity.Models;
using Comerciante.Pedido.Infra.Identity.Services;
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
            services.AddScoped<ContextUsuarios>();

            //Repository
            services.AddScoped<IColecaoRepository, ColecaoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ICorRepository, CorRepository>();
            services.AddScoped<IPedido_ReferenciaRepository, Pedido_ReferenciaRepository>();
            services.AddScoped<IPedido_Referencia_TamanhoRepository, Pedido_Referencia_TamanhoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IReferencia_ColecaoRepository, Referencia_ColecaoRepository>();
            services.AddScoped<IReferencia_CorRepository, Referencia_CorRepository>();
            services.AddScoped<IReferencia_TamanhoRepository, Referencia_TamanhoRepository>();
            services.AddScoped<IReferenciaRepository, ReferenciaRepository>();
            services.AddScoped<IReferencia_ImagemRepository, Referencia_ImagemRepository>();

            //Services
            services.AddScoped<IColecaoAppService, ColecaoAppService>();
            services.AddScoped<IContaAppService, ContaAppService>();
            services.AddScoped<ICorAppService, CorAppService>();
            services.AddScoped<IPedido_ReferenciaAppService, Pedido_ReferenciaAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();
            services.AddScoped<IReferencia_ColecaoAppService, Referencia_ColecaoAppService>();
            services.AddScoped<IPedido_Referencia_TamanhoAppService, Pedido_Referencia_TamanhoAppService>();
            services.AddScoped<IReferencia_CorAppService, Referencia_CorAppService>();
            services.AddScoped<IReferenciaAppService, ReferenciaAppService>();
            services.AddScoped<IReferencia_TamanhoAppService, Referencia_TamanhoAppService>();
            services.AddScoped<IReferenciaAppService, ReferenciaAppService>();
            services.AddScoped<IReferencia_ImagemAppService, Referencia_ImagemAppService>();
            services.AddScoped<IEmailAppService, EmailAppService>();
            //Identity
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IUser, AspNetUser>();

        }
    }
}
