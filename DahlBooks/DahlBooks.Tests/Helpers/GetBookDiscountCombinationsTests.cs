using System.Collections.Generic;
using AutoFixture;
using DahlBooks.Helpers;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace DahlBooks.Tests.Helpers
{
    public class GetBookDiscountCombinationsTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public GetBookDiscountCombinationsTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGet()
        {
            //Arrange
            var subject = Mocker.CreateInstance<GetBookDiscountCombinations>();
            var bookIdAndAmountOfOccurrences = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrences.Add(1, 2);
            bookIdAndAmountOfOccurrences.Add(2, 1);
            //Act
            var result = subject.Get(bookIdAndAmountOfOccurrences);
            //Assert
            result.Should().BeEquivalentTo(new[] {2, 1});
        }

        [Fact]
        public void WhenGetWithMultpleCombinations()
        {
            //Arrange
            var subject = Mocker.CreateInstance<GetBookDiscountCombinations>();
            var bookIdAndAmountOfOccurrences = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrences.Add(1, 2);
            bookIdAndAmountOfOccurrences.Add(2, 2);
            bookIdAndAmountOfOccurrences.Add(3, 3);

            //Act
            var result = subject.Get(bookIdAndAmountOfOccurrences);
            //Assert
            result.Should().BeEquivalentTo(new[] {3, 3, 1});
        }

        [Fact]
        public void WhenGetWithKataExample()
        {
            //Arrange
            var subject = Mocker.CreateInstance<GetBookDiscountCombinations>();
            var bookIdAndAmountOfOccurrences = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrences.Add(1, 2);
            bookIdAndAmountOfOccurrences.Add(2, 2);
            bookIdAndAmountOfOccurrences.Add(3, 2);
            bookIdAndAmountOfOccurrences.Add(4, 1);
            bookIdAndAmountOfOccurrences.Add(5, 1);
            //Act
            var result = subject.Get(bookIdAndAmountOfOccurrences);
            //Assert
            result.Should().BeEquivalentTo(new[] {4, 4});
        }
    }
}