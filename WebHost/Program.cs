using Application.Customers.Create;
using Application.Customers.Validation;
using FluentValidation;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using FluentValidation.AspNetCore;
using System.Reflection;
using Application.Customers;
using Application.Customers.Get;
using Application.Customers.Update;
using Domain.Customers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerValidation>();
builder.Services.AddTransient<IValidator<UpdateCustomerCommand>, UpdateCustomerValidation>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly));

var connectionString = configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
