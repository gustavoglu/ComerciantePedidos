using Comerciante.Pedido.Application.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Comerciante.Pedido.Application.Services
{
    public class AzureStorageHelper : IAzureStorageHelper
    {
        public CloudBlobClient GetBlobClient()
        {
            string accountName = "trevosstr";
            string key1 = "4mYpxgGqg+N/Xk5f3RE7v2f04+jqyk8nrRFQe3tbGIoeyyt0LL5hOBxJ81kr3Fi3XrrHBJPEAJ5zqrBbgdBI3Q==";
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key1), false);
            return storageAccount.CreateCloudBlobClient();
        }

        public CloudBlobContainer GetBlobContainer(string containerReference)
        {
            return GetBlobClient().GetContainerReference(containerReference);
        }

        public CloudBlockBlob GetBlockBlob(string containerReference, string fileName)
        {
            return GetBlobClient().GetContainerReference(containerReference).GetBlockBlobReference(fileName);
        }
    }
}
