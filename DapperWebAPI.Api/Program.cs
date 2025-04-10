using DapperWebAPI.Application.Handlers;
using DapperWebAPI.Domain.Interfaces;
using DapperWebAPI.Infrastructure.Data;
using DapperWebAPI.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddSingleton<DapperContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();