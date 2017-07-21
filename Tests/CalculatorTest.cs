using System;
using FluentAssertions;
using Solid.CleanCode;
using Xunit;

namespace Tests
{
  public class CalculatorTest
  {
    [Fact]
    public void ShouldAddTwoNumbers()
    {
      var calculator = new Calculator();

      var result = calculator.Add(3, 5);

      const int expected = 8;
      result.Should().Be(expected);
    }
  }
}
