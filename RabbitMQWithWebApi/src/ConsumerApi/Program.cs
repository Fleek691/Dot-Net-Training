using ConsumerApi.Services;
using ProducerApi.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection(RabbitMqOptions.SectionName));
builder.Services.AddSingleton<ReceivedMessageStore>();
builder.Services.AddHostedService<RabbitMqConsumerService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    service = "Consumer API",
    description = "Reads messages from RabbitMQ and keeps them in memory for inspection."
}));

app.MapGet("/messages", (ReceivedMessageStore store) => Results.Ok(store.GetAll()))
    .WithName("GetReceivedMessages")
    .WithOpenApi();

app.Run();
