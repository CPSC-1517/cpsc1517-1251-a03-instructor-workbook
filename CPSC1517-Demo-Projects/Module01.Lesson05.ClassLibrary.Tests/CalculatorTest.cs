namespace Module01.Lesson05.ClassLibrary.Tests
{
    using FluentAssertions; // for Should() extension method

    public class CalculatorTest
    {
        [Fact]
        public void Add_ShouldReturnSum_WhenTwoPositiveIntegers()
        {
            // Arrange
            int x = 2;
            int y = 3;

            // Act
            int result = Calculator.Add(x, y);

            // Assert
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(2,3,5)]
        [InlineData(-1,1,0)]
        [InlineData(0,0,0)]
        public void Add_ShowReturnExpectedSum(int x, int y, int expectedResult)
        {
            // Arrange and Act
            int actualResult = Calculator.Add(x, y);
            
            // Assert (xUnit)
            Assert.Equal(expectedResult, actualResult);

            // Assert (FluentAssertion )
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(10, -5, -2)]
        [InlineData(-100, -5, 20)]
        public void Divide_ShouldReturnQuotient(int numerator, int denominator, int expectedResult)
        {
            // Arrange and Act
            var actualResult = Calculator.Divide(numerator, denominator);

            // Assert (xUnit)
            Assert.Equal(expectedResult, actualResult);

            // Assert (FluentAssertion)
            actualResult.Should().Be(expectedResult);
        }

        [Fact]
        public void Divide_ShowThrow_WhenDenominatorIsZero()
        {
            // Arrange and Act
            Action act = () => Calculator.Divide(20,0);
            // Assert (FluentAssertion)
            act.Should().Throw<DivideByZeroException>()
                .WithMessage("*zero*");
        }
    }
}
