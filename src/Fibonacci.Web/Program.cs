using Fibonacci;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using var dataContext = new FibonacciDataContext();
var fibonacciService = new Compute(dataContext);

app.MapGet("/", () => "Hello World!");
app.MapGet("/fibonacci", async () => await fibonacciService.ExecuteAsync(new[] {"44", "44", "44"}));

app.Run();