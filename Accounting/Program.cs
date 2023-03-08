using Abc.Accounting;
using Sitecore.Messaging;
using Sitecore.Messaging.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessagingService(builder.Configuration);
builder.Services.AddSingleton<IConsumerService, AccountConsumerService>();
builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/order", async (IConsumerService consumerService) =>
{
    return new Order(Guid.NewGuid(), string.Empty);
})
.WithName("get-latest");

app.Run();

public record Order(Guid orderId, string remarks);