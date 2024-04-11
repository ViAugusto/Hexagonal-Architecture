using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface ISqsService
    {
        Task<ReceiveMessageResponse> ConsumeSqsMessageAsync(string queueUrl);
    }
}
