using PAINotificationService;
using Quartz;
using Quartz.Simpl;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddQuartz(options =>
{
    options.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();
});

builder.WebHost.UseUrls("http://localhost:5001");
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

builder.Services.ConfigureOptions<NotificationConfiguation>();
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();
