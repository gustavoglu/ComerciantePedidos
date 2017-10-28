using System;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IEmailAppService : IDisposable
    {
        Task<string> CriaTabela(Guid id_pedido);

        void EnviaEmail(Guid id_pedido);
    }
}
