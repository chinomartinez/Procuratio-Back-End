using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Azure
{
    public interface IFileStorage
    {
        Task<string> SaveFile(string container, IFormFile file);

        Task DeleteFile(string path, string container);

        Task<string> EditFile(string container, IFormFile file, string path);
    }
}
