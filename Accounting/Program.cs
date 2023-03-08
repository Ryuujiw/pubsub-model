using Abc.Accounting;
using Abc.Accounting.Services;
using Sitecore.Messaging;
using Sitecore.Messaging.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessagingService(builder.Configuration);
builder.Services.AddSingleton<IConsumerService, AccountConsumerService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IStandardsService, StandardsService>();
builder.Services.AddHostedService<ConsumerHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/orders/get-latest", async (IConsumerService consumerService) =>
{
    var latest = AccountData.Orders.LastOrDefault();
    return latest;
})
.WithName("get-latest");

app.Run();

public record Order(Guid orderId, string remarks);