using Polly;
using Polly.Extensions.Http;
using PollyRetry.API.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPollyRetryService, PollyRetryService>();

builder.Services.AddHttpClient<IPollyRetryService, PollyRetryService>()
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddPolicyHandler(
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            //.WaitAndRetryAsync(5, retryAttempts => TimeSpan.FromSeconds(Math.Pow(2, retryAttempts)))
            .WaitAndRetryAsync(3, retryAttempts => TimeSpan.FromSeconds(1))
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
