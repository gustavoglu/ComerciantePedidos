using Microsoft.WindowsAzure.Storage.Blob;

namespace Comerciante.Pedido.Application.Interfaces
{
    public interface IAzureStorageHelper
    {
        CloudBlobClient GetBlobClient();

        CloudBlobContainer GetBlobContainer(string containerReference);

        CloudBlockBlob GetBlockBlob(string containerReference, string fileName);
    }
}
