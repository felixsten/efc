﻿using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\efc\Infrastructure\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CategoryService>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ProductService>();
    services.AddScoped<AddressRepository>();
    services.AddScoped<AddressService>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<CustomerService>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<RoleService>();

    services.AddSingleton<MenuService>();

}).Build();

builder.Start();

Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();



