using Application.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly S3ApplicationService _applicationService;

        public Worker(ILogger<Worker> logger, S3ApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Exeutado as: {DateTime.Now}");


            string queue = "queue_do_vini";
            try
            {
                await _applicationService.ProcessarMensagemSqsAsync(queue);
                _logger.LogInformation($"{queue} executado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro no processamento: {ex}");
            }
        }
    }
}
