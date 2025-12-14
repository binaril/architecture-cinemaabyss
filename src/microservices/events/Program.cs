using events.Consumers;
using events.Middleware;
using events.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<EventsService>();
builder.Services.AddTransient<ConsumerSourceService>();
builder.Services.AddSingleton<KafkaProducer>();

builder.Services.AddHostedService<MoviesConsumer>();
builder.Services.AddHostedService<PaymentsConsumer>();
builder.Services.AddHostedService<UsersConsumer>();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();

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