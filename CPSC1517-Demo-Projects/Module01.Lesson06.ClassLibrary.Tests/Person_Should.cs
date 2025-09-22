namespace Module01.Lesson06.ClassLibrary.Tests
{
    using FluentAssertions; // for Should() extension method

    public class Person_Should
    {
        [Fact]
        public void Create_Default_Instance()
        {
            // Arrange and Act
            var sut = new Person();
            // Assert
            sut.FirstName.Should().Be("Unknown");
            sut.LastName.Should().Be("Unknown");
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Should().BeEmpty();
        }

        [Fact]
        public void Create_With_Trimmed_First_And_Last_Name()
        {
            var sut = new Person("  Don  ", "  Welch  ", null, null);
            sut.FirstName.Should().Be("Don");
            sut.LastName.Should().Be("Welch");
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Throw_Exception_When_FirstName_Is_Missing(string firstname)
        {
            Action action = () => new Person(firstname, "Welch", null, null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FullName_ValidValues_ReturnCorrectFormat()
        {
            // Arrange and Act
            var sut = new Person("Don", "Welch", null, null);
            // Assert
            sut.FullName.Should().Be("Welch, Don");
        }
    }
}
