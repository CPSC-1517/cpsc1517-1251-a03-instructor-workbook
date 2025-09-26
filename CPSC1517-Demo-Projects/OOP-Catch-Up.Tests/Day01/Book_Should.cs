namespace OOP_Catch_Up.Tests.Day01
{
    using FluentAssertions; // for Should() extension method
    using OOP_Catch_Up.Models; // for Book class

    public class Book_Should
    {
        [Fact]
        public void Book_Should_SetValues()
        {
            // Arrange 
            string title = "Everybody loves C#";
            int pages = 2;

            // Act
            var book1 = new Book(title, pages);

            // Assert
            book1.Title.Should().Be(title);
            book1.Pages.Should().Be(pages);

        }

        [Fact]
        public void Book_Should_ThrowException_WhenTitleIsBlank()
        {
            // Arrange 
            string title = "        ";
            int pages = 2;

            // Act
            Action act = () => new Book(title, pages);

            // Assert
            act.Should().Throw<ArgumentNullException>();

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Book_Should_ThrowException_WhenPagesLessOrEqualZero(int pages)
        {
            // Arrange 
            string title = "Things to do Fridays";

            // Act
            Action act = () => new Book(title, pages);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();

        }
    }
}
