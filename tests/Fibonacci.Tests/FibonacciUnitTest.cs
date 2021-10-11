using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Fibonacci.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Fibonacci_Sould_CalculateFibonacciValue_When_InputIsGiven()
        {
            var input = "44";

            var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
            var dataBaseName = Guid.NewGuid().ToString();
            builder.UseInMemoryDatabase(dataBaseName);
            var options = builder.Options;
            
            var fibonacciDataContext = new FibonacciDataContext(options);
            await fibonacciDataContext.Database.EnsureCreatedAsync();
            var fibonacciService = new Compute(fibonacciDataContext);

            var res = await fibonacciService.ExecuteAsync(new[] {input});

            Assert.Equal(701408733, res[0]);
        }
    }
}