using Amazon.SQS.Model;

namespace Domain.Ports
{
    public interface ISqsService
    {
        Task<ReceiveMessageResponse> ConsumeSqsMessageAsync(string queueUrl);
    }
}
