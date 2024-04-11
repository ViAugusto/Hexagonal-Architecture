using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Domain.Ports;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AWS
{
    public class S3Adapter : IS3Service
    {
        private readonly IAmazonS3 _s3Client;

        public S3Adapter(IConfiguration configuration)
        {
            var accessKeyId = configuration["AWSCredentials:AccessKeyId"];
            var secretAccessKey = configuration["AWSCredentials:SecretAccessKey"];
            var region = configuration["AWSCredentials:Region"];

            var awsOptions = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };

            _s3Client = new AmazonS3Client(accessKeyId, secretAccessKey, awsOptions);
        }

        public async Task<byte[]> DownloadFileAsync(string bucketName, string filePath)
        {
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = filePath
            };

            using (var response = await _s3Client.GetObjectAsync(request))
            {
                // Ler o conteúdo do arquivo em um MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(memoryStream);

                    // Converter o MemoryStream em uma matriz de bytes
                    return memoryStream.ToArray();
                }
            }
        }
    }
}