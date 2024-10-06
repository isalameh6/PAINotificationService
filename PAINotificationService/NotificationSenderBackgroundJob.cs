using Quartz;

namespace PAINotificationService
{
    [DisallowConcurrentExecution]
    public class NotificationSenderBackgroundJob(ILogger<NotificationSenderBackgroundJob> _Logger) : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            _Logger.LogInformation($"Current DateTime {DateTime.Now}");
            return Task.CompletedTask;
        }
    }

}
