using Microsoft.Azure.Storage.Blob;

namespace Bupa.PXC.CommsFulfilment.Common.Services
{
    public class BlobstorageService : IBlobstorageService
    {
        private readonly CloudBlobContainer _container;
        public BlobstorageService(CloudBlobClient blobClient, string container)
        {
            _container = blobClient.GetContainerReference(container);
        }

        public async Task UploadFileToBlob(
           string data,
           string fileName
       )
        {
            // Get a reference to the blob
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(fileName);

            // Upload file
            await blockBlob.UploadTextAsync(data.ToString());
        }
    }
}
