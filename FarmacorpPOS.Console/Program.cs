using FarmacorpPOS.Application.DependencyInjection;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddInfrastructure(
    configuration.GetConnectionString("DefaultConnection")!);

services.AddApplication();

var serviceProvider =
    services.BuildServiceProvider();

Console.WriteLine("Dependencias configuradas correctamente.");