using FarmacorpPOS.Application.DependencyInjection;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FarmacorpPOS.Domain.Strategies;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

var businessMode =
    configuration["BusinessMode"] ?? "Base";

if (businessMode.Equals(
        "GanaMax",
        StringComparison.OrdinalIgnoreCase))
{
    services.AddScoped<IPriceStrategy,
        GanaMaxPriceStrategy>();

    services.AddScoped<IDiscountStrategy,
        GanaMaxDiscountStrategy>();

    services.AddScoped<IStockStrategy,
        GanaMaxStockStrategy>();
}
else
{
    services.AddScoped<IPriceStrategy,
        BasePriceStrategy>();

    services.AddScoped<IDiscountStrategy,
        BaseDiscountStrategy>();

    services.AddScoped<IStockStrategy,
        BaseStockStrategy>();
}

services.AddInfrastructure(
    configuration.GetConnectionString("DefaultConnection")!);

services.AddApplication();

var serviceProvider =
    services.BuildServiceProvider();

while (true)
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("FARMACORP POS EXPRESS");
    Console.WriteLine("=================================");
    Console.WriteLine();

    Console.WriteLine($"Modo de Negocio: {businessMode}");
    Console.WriteLine();

    Console.WriteLine("1. Registrar Producto ERP");
    Console.WriteLine("2. Registrar Categoría");
    Console.WriteLine("3. Asignar Categoría a Producto");
    Console.WriteLine("4. Registrar Venta");
    Console.WriteLine("5. Asignar Código de Barras");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            await RegistrarProducto(serviceProvider);
            break;

        case "2":
            await RegistrarCategoria(serviceProvider);
            break;

        case "3":
            await AsignarCategoriaProducto(serviceProvider);
            break;

        case "4":
            await RegistrarVenta(serviceProvider);
            break;

        case "5":
            await RegistrarCodigoBarra(serviceProvider);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opción inválida");
            Console.ReadKey();
            break;
    }
}

static async Task RegistrarProducto(
    IServiceProvider serviceProvider)
{
    Console.Clear();

    Console.WriteLine("=== REGISTRO PRODUCTO ERP ===");
    Console.WriteLine();

    Console.Write("Nombre: ");
    var nombre = Console.ReadLine() ?? "";

    Console.Write("Costo: ");
    var costo = decimal.Parse(Console.ReadLine() ?? "0");

    Console.Write("Stock: ");
    var stock = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine();
    Console.WriteLine("Tipos de Producto:");
    Console.WriteLine("1 - Medicamento");
    Console.WriteLine("2 - Cosmético");
    Console.WriteLine("3 - Higiene");
    Console.WriteLine("4 - Suplemento");

    Console.WriteLine();

    Console.Write("Id Tipo Producto: ");
    var idTipoProducto =
        int.Parse(Console.ReadLine() ?? "0");

    var productoService =
        serviceProvider.GetRequiredService<IProductoService>();

    await productoService.RegistrarProductoAsync(
        nombre,
        costo,
        stock,
        idTipoProducto);

    Console.WriteLine();
    Console.WriteLine("Producto registrado correctamente.");

    Console.ReadKey();
}

static async Task RegistrarCategoria(
    IServiceProvider serviceProvider)
{
    Console.Clear();

    Console.WriteLine("=== REGISTRO DE CATEGORÍA ===");
    Console.WriteLine();

    Console.Write("Descripción: ");
    var descripcion = Console.ReadLine() ?? "";

    Console.Write("Id Categoría Padre (Enter para ninguna): ");
    var input = Console.ReadLine();

    int? idPadre = null;

    if (!string.IsNullOrWhiteSpace(input))
    {
        idPadre = int.Parse(input);
    }

    var categoriaService =
        serviceProvider.GetRequiredService<ICategoriaService>();

    await categoriaService.RegistrarCategoriaAsync(
        descripcion,
        idPadre);

    Console.WriteLine();
    Console.WriteLine("Categoría registrada correctamente.");

    Console.ReadKey();
}

static async Task AsignarCategoriaProducto(
    IServiceProvider serviceProvider)
{
    Console.Clear();

    Console.WriteLine("=== ASIGNAR CATEGORÍA A PRODUCTO ===");
    Console.WriteLine();

    Console.Write("Id Producto: ");
    var idProducto = int.Parse(
        Console.ReadLine() ?? "0");

    Console.Write("Id Categoría: ");
    var idCategoria = int.Parse(
        Console.ReadLine() ?? "0");

    var categoriaService =
        serviceProvider.GetRequiredService<ICategoriaService>();

    await categoriaService
        .AsignarCategoriaProductoAsync(
            idProducto,
            idCategoria);

    Console.WriteLine();
    Console.WriteLine("Categoría asignada correctamente.");

    Console.ReadKey();
}

static async Task RegistrarVenta(
    IServiceProvider serviceProvider)
{
    Console.Clear();

    Console.WriteLine("=== REGISTRO DE VENTA ===");
    Console.WriteLine();

    Console.Write("Id Producto: ");
    var idProducto =
        int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Cliente: ");
    var cliente =
        Console.ReadLine() ?? "";

    Console.Write("Cantidad: ");
    var cantidad =
        int.Parse(Console.ReadLine() ?? "0");

    try
    {
        var ventaService =
            serviceProvider.GetRequiredService<IVentaService>();

        var total =
            await ventaService.RegistrarVentaAsync(
                idProducto,
                cantidad,
                cliente);

        Console.WriteLine();
        Console.WriteLine($"Venta registrada.");
        Console.WriteLine($"Total: {total:C}");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.ReadKey();
}

static async Task RegistrarCodigoBarra(
    IServiceProvider serviceProvider)
{
    Console.Clear();

    Console.WriteLine("=== ASIGNAR CÓDIGO DE BARRAS ===");
    Console.WriteLine();

    Console.Write("Id Producto: ");

    var idProducto =
        int.Parse(Console.ReadLine() ?? "0");

    try
    {
        var codigoBarraService =
            serviceProvider.GetRequiredService<ICodigoBarraService>();

        await codigoBarraService
            .RegistrarCodigoBarraAsync(idProducto);

        Console.WriteLine();
        Console.WriteLine("Código de barras asignado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.ReadKey();
}