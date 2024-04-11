using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IS3Service
    {
        Task<byte[]> DownloadFileAsync(string bucketName, string filePath);
    }
}
