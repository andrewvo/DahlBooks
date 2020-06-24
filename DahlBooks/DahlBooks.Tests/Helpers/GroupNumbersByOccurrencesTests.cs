using System.Collections.Generic;
using AutoFixture;
using DahlBooks.Helpers;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace DahlBooks.Tests.Helpers
{
    public class GroupNumbersByOccurrencesTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public GroupNumbersByOccurrencesTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGroup()
        {
            //Arrange
            var subject = Mocker.CreateInstance<GroupNumbersByOccurrences>();
            var books = new[] {1, 1, 1, 2, 2, 2, 3, 3, 4, 5, 5};
            var groupedBooks = new Dictionary<int, int>();
            groupedBooks.Add(1, 3);
            groupedBooks.Add(2, 3);
            groupedBooks.Add(3, 2);
            groupedBooks.Add(4, 1);
            groupedBooks.Add(5, 2);
            //Act
            var result = subject.Group(books);
            //Assert
            result.Should().BeEquivalentTo(groupedBooks);
        }
    }
}