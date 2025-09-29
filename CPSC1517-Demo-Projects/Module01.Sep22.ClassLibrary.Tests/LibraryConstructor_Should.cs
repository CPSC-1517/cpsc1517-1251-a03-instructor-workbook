namespace Module01.Sep22.ClassLibrary.Tests
{
    using FluentAssertions;

    public class LibraryConstructor_Should
    {
        [Fact]
        public void Constructor_RequiredFieldsOnly_Succeeds()
        {
            // Arrange 
            string libraryId = "Library01";
            string libraryName = "LibraryName01";
            // Act
            var library1 = new Library(libraryId, libraryName);
            // Assert
            library1.TotalBooks.Should().Be(0);
            library1.Address.Should().BeNull();
            library1.LibraryId.Should().Be(libraryId);
            library1.Name.Should().Be(libraryName);
        }

        [Fact]
        public void Constructor_WithAddressTrim_AddressIsTrimmed()
        {
            // Arrange 
            string libraryId = "Library01";
            string libraryName = "LibraryName01";
            string libraryAddress = "   Library Address     ";   
            // Act
            var library1 = new Library(libraryId, libraryName, libraryAddress);
            // Assert
            library1.TotalBooks.Should().Be(0);
            library1.Address.Should().Be(libraryAddress.Trim());
            library1.LibraryId.Should().Be(libraryId);
            library1.Name.Should().Be(libraryName);
        }

        [Fact]
        public void Constructor_WithBookList_Succeed()
        {
            // Arrange 
            string libraryId = "Library01";
            string libraryName = "LibraryName01";
            string libraryAddress = "   Library Address     ";
            var bookList = new List<Book>()
            {
                new Book("ISBN1","BookTitle1","BookAuthor1",10),
                new Book("ISBN2","BookTitle2","BookAuthor2",20)
            };


            // Act
            var library1 = new Library(libraryId, libraryName, libraryAddress, bookList);
            
            // Assert
            library1.TotalBooks.Should().Be(2);
            library1.Address.Should().Be(libraryAddress.Trim());
            library1.LibraryId.Should().Be(libraryId);
            library1.Name.Should().Be(libraryName);
            library1.Books.Should().HaveCount(2)
                .And.ContainSingle(b => b.ISBN == "ISBN1")
                .And.ContainSingle(b => b.ISBN == "ISBN2");

        }

        [Fact]
        public void Constructor_DuplicateISBN_ThrowsArgumentException()
        {
            // Arrange 
            string libraryId = "Library01";
            string libraryName = "LibraryName01";
            string libraryAddress = "   Library Address     ";
            var bookList = new List<Book>()
            {
                new Book("ISBN1","BookTitle1","BookAuthor1",10),
                new Book("ISBN1","BookTitle2","BookAuthor2",20)
            };


            // Act
            Action act = () => new Library(libraryId, libraryName, libraryAddress, bookList);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("*duplicate*");

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void Constructor_MissingName_ThrowsArgumentNullException(string libraryName)
        {
            // Arrange 
            string libraryId = "Library01";

            // Act
            Action act = () => new Library(libraryId, libraryName);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("Name"); 
        }
    }
}
