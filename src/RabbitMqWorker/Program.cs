using WebApi;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<RabbitMqWorker>();

var host = builder.Build();
host.Run();
