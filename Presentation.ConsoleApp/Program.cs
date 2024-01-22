﻿using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\efc\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddScoped<CategoryRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ProductService>();
    services.AddScoped<MenuService>();

}).Build();

builder.Start();

Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();