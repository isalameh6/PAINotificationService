using Microsoft.Extensions.Options;
using Quartz;

namespace PAINotificationService
{
    public class NotificationConfiguation : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var jobKey = JobKey.Create(nameof(NotificationSenderBackgroundJob));

            options.AddJob<NotificationSenderBackgroundJob>(jobBuilder =>
                jobBuilder.WithIdentity(jobKey));

            options.AddTrigger(trigger => trigger
                .ForJob(jobKey)
                .WithDailyTimeIntervalSchedule(schedule =>
                    schedule
                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(9, 0))   // Start at 9 AM
                        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(14, 0))    // End at 12 PM
                        .OnDaysOfTheWeek(DayOfWeek.Sunday, DayOfWeek.Monday,
                                         DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                         DayOfWeek.Thursday, DayOfWeek.Saturday)                    // Run on Sunday to Thursday
                        .WithIntervalInSeconds(3)));                              // Trigger every hour
        }

    }
}
