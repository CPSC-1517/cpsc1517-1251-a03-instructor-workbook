namespace Module01.HiringHelper.Tests
{
    using FluentAssertions;
    using Xunit;

    public class Employment_HappyPath
    {
        [Fact]
        public void GreedyCtor_BuildsValidObject_AndCalculatesWeeklyPay()
        {
            //var emp = new Employment("AB1234", "Jan Lee", SupervisoryLevel.Lead, 40m, 37.5);

            //emp.EmployeeId.Should().Be("AB1234");
            //emp.FullName.Should().Be("Jan Lee");
            //emp.Level.Should().Be(SupervisoryLevel.Lead);
            //emp.HourlyRate.Should().Be(40m);
            //emp.HoursPerWeek.Should().Be(37.5);
            //emp.WeeklyPay.Should().Be(1500m); // 40 * 37.5

            //emp.ToString().Should().Be("AB1234 | Jan Lee | Lead | $40.00/hr x 37.5h = $1500.00");
        }

        [Fact]
        public void DefaultCtor_ThenSetProperties_Succeeds()
        {
            //var emp = new Employment
            //{
            //    EmployeeId = "CD5678",
            //    FullName = "Ali Khan",
            //    Level = SupervisoryLevel.Manager,
            //    HourlyRate = 60m,
            //    HoursPerWeek = 40
            //};

            //emp.WeeklyPay.Should().Be(2400m);
            //emp.Level.Should().Be(SupervisoryLevel.Manager);
        }
    }
}
