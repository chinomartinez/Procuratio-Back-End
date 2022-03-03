using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Procuratio.Shared.Abstractions.Azure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.Azure
{
    internal class AzureStorageContainer : IFileStorage
    {
        private readonly string ConnectionString;

        public AzureStorageContainer(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("AzureStorage");
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            BlobContainerClient client = new(ConnectionString, container);

            await client.CreateIfNotExistsAsync();

            client.SetAccessPolicy(PublicAccessType.Blob);

            string extension = Path.GetExtension(file.FileName);

            string fileName = $"{Guid.NewGuid()}{extension}";

            BlobClient blob = client.GetBlobClient(fileName);

            await blob.UploadAsync(file.OpenReadStream());

            return blob.Uri.ToString();
        }

        public async Task DeleteFile(string path, string container)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            BlobContainerClient client = new(ConnectionString, container);

            await client.CreateIfNotExistsAsync();

            string file = Path.GetFileName(path);

            BlobClient blob = client.GetBlobClient(file);

            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> EditFile(string container, IFormFile file, string path)
        {
            await DeleteFile(path, container);

            return await SaveFile(container, file);
        }
    }
}
