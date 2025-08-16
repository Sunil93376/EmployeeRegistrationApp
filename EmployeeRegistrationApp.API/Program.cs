using EmployeeRegistrationApp.Application.Handlers;
using EmployeeRegistrationApp.Application.Interfaces;
using EmployeeRegistrationApp.Infrastructure.Data;
using EmployeeRegistrationApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeRegistrationApp.Application.Handlers; // or any type from Application



var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<EmployeeContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ERADEFAULT")));

// Application services
//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(CreateEmployeeHandler).Assembly);

//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Infrastructure
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}