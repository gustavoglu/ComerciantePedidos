using System.IO;
using System.Threading.Tasks;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IBlobAppService
    {
        Task<string> Upload(string containerName, string nameFile, Stream streamFile);

        Task<bool> Deletar(string containerName, string nameFile);

        Task<bool> Deletar(string containerName, string[] namesFile);
    }
}
