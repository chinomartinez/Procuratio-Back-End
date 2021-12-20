using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Procuratio.Shared.Abstractions.Messaging;
using Procuratio.Shared.Abstractions.Modules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    internal sealed class AsynchronusDispacherJob : BackgroundService
    {
        private readonly IMessageChannel _messageChannel;
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<AsynchronusDispacherJob> _logger;

        public AsynchronusDispacherJob(IMessageChannel messageChannel, IModuleClient moduleClient, ILogger<AsynchronusDispacherJob> logger)
        {
            _messageChannel = messageChannel;
            _moduleClient = moduleClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Running async dispacher job.");

            await foreach (IMessage message in _messageChannel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            _logger.LogInformation("Finished running async dispacher job.");
        }
    }
}
