using Xunit;

namespace Fibonacci.Tests
{

    public class UnitTest1
    {
        [Fact]
        public async void Fibonacci_Sould_CalculateFibonacciValue_When_InputIsGiven()
        {
            var input = "44";

            var res = await Compute.ExecuteAsync(new []{input});
            
            Assert.Equal(701408733, res[0]);
        }
    }
}