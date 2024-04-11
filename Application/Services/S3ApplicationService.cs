using Amazon.SQS.Model;
using Domain.Ports;

namespace Application.Services
{
    public class S3ApplicationService
    {
        private readonly IS3Service _s3Service;
        private readonly ISqsService _sqsService;

        public S3ApplicationService(IS3Service s3Service, ISqsService sqsService)
        {
            _s3Service = s3Service;
            _sqsService = sqsService;

        }

        public async Task ProcessarMensagemSqsAsync(string queueUrl)
        {
            try
            {
                ReceiveMessageResponse message = await _sqsService.ConsumeSqsMessageAsync(queueUrl);

                foreach (var m in message.Messages)
                {
                    string filePath = m.Body.ToString();
                    string bucketName = "bucketTeste";

                    await ConsumeS3BucketAsync(filePath, bucketName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ConsumeS3BucketAsync(string bucketName, string filePath)
        {
            try
            {
                byte[] fileData = await _s3Service.DownloadFileAsync(bucketName, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
