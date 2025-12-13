using proxy.Middleware;
using proxy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddTransient<UsersGatewayService>();
builder.Services.AddTransient<MovieGatewayService>();
builder.Services.AddTransient<SubscriptionsGatewayService>();
builder.Services.AddTransient<PaymentsGatewayService>();
builder.Services.AddTransient<HealthGatewayService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();