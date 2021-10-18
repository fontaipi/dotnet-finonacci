using System.IO;
using Fibonacci;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var services = new ServiceCollection()
    .AddDbContext<FibonacciDataContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddTransient<Compute>()
    .AddLogging();

using var serviceProvider = services.BuildServiceProvider();

var compute = serviceProvider.GetService<Compute>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/fibonacci", async () => await compute.ExecuteAsync(new[] {"44", "44", "44"}));

app.Run();