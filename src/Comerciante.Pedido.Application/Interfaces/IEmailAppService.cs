using System;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IEmailAppService
    {
        string CriaTabela(Guid id_pedido);

        void EnviaEmail(string body, string usuario, int pedidoNumero);
    }
}
