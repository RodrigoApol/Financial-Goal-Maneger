using System.Text.Json.Serialization;
using FinancialGoalManager.Application.Configuration;
using FinancialGoalManager.Infrastructure.Configuration;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddControllers()
    .AddJsonOptions(o => 
        o.JsonSerializerOptions
            .Converters
            .Add(new JsonStringEnumConverter()));

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
