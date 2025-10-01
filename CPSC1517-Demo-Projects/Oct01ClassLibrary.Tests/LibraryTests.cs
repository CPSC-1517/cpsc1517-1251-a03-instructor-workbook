namespace Oct01ClassLibrary.Tests
{
    using FluentAssertions; // for Should() extension method
    using System.ComponentModel.DataAnnotations;

    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldIncreaseCount()
        {
            // Arrange
            var library = new Library();
            var book = new Book { Title = "Clean Code" };

            // Act
            library.AddBook(book);

            // Assert
            library.Books.Should().ContainSingle(b => b.Title == "Clean Code");
        }

        [Fact]
        public void AddBook_WhenBookIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var library = new Library();
            Book? book = null;

            // Act
            Action act = () => library.AddBook(book);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("*cannot be null*");
        }

        [Fact]
        public void RemoveBook_ShouldRemoveByTitle()
        {
            var library = new Library();
            library.AddBook(new Book { Title = "Domain-Driven Design" });

            library.RemoveBook("Domain-Driven Design");

            library.Books.Should().NotContain(b => b.Title == "Domain-Driven Design");
        }

        [Fact]
        public void RemoveBook_ShouldThrowArgumentException()
        {
            // Arrange
            var library = new Library();
            library.AddBook(new Book { Title = "Domain-Driven Design" });

            // Act
            Action act = () => library.RemoveBook("Domain-Driven");

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("*does not exists*");
        }
    }
}
