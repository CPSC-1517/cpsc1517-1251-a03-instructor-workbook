namespace Module01.HiringHelper.Tests
{
    using FluentAssertions;
    using Xunit;

    public class Employment_Validation
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void FullName_Blank_Throws(string? bad)
        {
            var act = () => new Employment { FullName = bad! };
            act.Should().Throw<ArgumentException>()
               .WithMessage("*FullName*");
        }

        [Theory]
        [InlineData("A1234")]
        [InlineData("AB12X4")]
        [InlineData("abc123")] // not uppercase
        public void EmployeeId_InvalidPattern_Throws(string badId)
        {
            var act = () => new Employment { EmployeeId = badId };
            act.Should().Throw<ArgumentException>()
               .WithMessage("*EmployeeId*");
        }

        [Theory]
        [InlineData(14.99)]
        [InlineData(250.01)]
        public void HourlyRate_OutOfRange_Throws(double bad)
        {
            var act = () => new Employment { HourlyRate = (decimal)bad };
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(60.1)]
        public void HoursPerWeek_OutOfRange_Throws(double bad)
        {
            var act = () => new Employment { HoursPerWeek = bad };
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WeeklyPay_ReactsToChanges()
        {
            var emp = new Employment("EF9012", "Maria Lopez", SupervisoryLevel.Supervisor, 45m, 38);
            emp.WeeklyPay.Should().Be(1710m);

            emp.HourlyRate = 50m;
            emp.WeeklyPay.Should().Be(1900m);

            emp.HoursPerWeek = 40;
            emp.WeeklyPay.Should().Be(2000m);
        }
    }
}
