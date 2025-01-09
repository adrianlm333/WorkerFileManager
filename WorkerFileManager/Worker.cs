using Sample;

namespace WorkerFileManager
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                MonitorUpdaterManagerSample.UpdateMonitor("C:\\Deploy\\TestFolder", "C:\\Deploy\\TargetFolder", "1");
                await Task.Delay(120000, stoppingToken);
            }
        }
    }
}
