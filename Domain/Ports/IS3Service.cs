

namespace Domain.Ports
{
    public interface IS3Service
    {
        Task<byte[]> DownloadFileAsync(string bucketName, string filePath);
    }
}
