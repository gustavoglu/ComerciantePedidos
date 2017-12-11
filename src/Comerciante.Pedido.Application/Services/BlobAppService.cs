using System.IO;
using System.Threading.Tasks;
using Comerciante.Pedido.Application.Interfaces;

namespace Comerciante.Pedido.Application.Services
{
    public class BlobAppService  : IBlobAppService
    {
        private readonly IAzureStorageHelper _azureStorageHelper;

        public BlobAppService(IAzureStorageHelper azureStorageHelper)
        {
            _azureStorageHelper = azureStorageHelper;
        }

        public async Task<bool> Deletar(string containerName,string nameFile)
        {
            var blockBlob = _azureStorageHelper.GetBlockBlob(containerName, nameFile);
            return await blockBlob.DeleteIfExistsAsync();
        }

        public async Task<bool> Deletar(string containerName, string[] namesFile)
        {
            try
            {
                foreach (var nameFile in namesFile)
                {
                    var blockBlob = _azureStorageHelper.GetBlockBlob(containerName, nameFile);
                    await blockBlob.DeleteIfExistsAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> Upload(string containerName,string nameFile,Stream streamFile)
        {
            var blockBlob = _azureStorageHelper.GetBlockBlob(containerName, nameFile);
            await blockBlob.UploadFromStreamAsync(streamFile);
            return blockBlob.Uri.AbsolutePath; ;
        }
    }
}
