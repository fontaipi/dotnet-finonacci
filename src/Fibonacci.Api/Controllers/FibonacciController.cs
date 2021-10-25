using System.Collections.Generic;
using System.Threading.Tasks;
using Fibonacci;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fibonacci.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FibonacciController : ControllerBase
{
    private readonly ILogger<FibonacciController> _logger;
    private readonly Compute _compute;

    public FibonacciController(ILogger<FibonacciController> logger, Compute compute)
    {
        _logger = logger;
        _compute = compute;
    }

    [HttpGet]
    public async Task<IEnumerable<long>> Get()
    {
        return await _compute.ExecuteAsync(new[] {"44", "44", "44"});
    }
}