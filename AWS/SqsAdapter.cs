using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Domain.Ports;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS
{
    public class SqsAdapter : ISqsService
    {
        private readonly IAmazonSQS _sqsClient;

        public SqsAdapter(IConfiguration configuration)
        {
            var accessKeyId = configuration["AWSCredentials:AccessKeyId"];
            var secretAccessKey = configuration["AWSCredentials:SecretAccessKey"];
            var region = configuration["AWSCredentials:Region"];

            AmazonSQSConfig awsOptions = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };

            _sqsClient = new AmazonSQSClient(accessKeyId, secretAccessKey, awsOptions);   
        }

        public async Task<ReceiveMessageResponse> ConsumeSqsMessageAsync(string queueUrl)
        {
            ReceiveMessageRequest request = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl,
                MaxNumberOfMessages = 1
            };

            var response = await _sqsClient.ReceiveMessageAsync(request);
            return response;
        }
    }
}
