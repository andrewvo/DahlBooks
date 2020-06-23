using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using DahlBooks.Helpers;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace DahlBooks.Tests.Helpers
{
    public class CalculateDiscountedPriceTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public CalculateDiscountedPriceTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenCalculateFor5PercentDiscount()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 1);
            bookIdAndAmountOfOccurrances.Add(2, 1);
            var expectedCombinations = new[] {2}.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(15.2m);
        }

        [Fact]
        public void WhenCalculateFor10PercentDiscount()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 1);
            bookIdAndAmountOfOccurrances.Add(2, 1);
            bookIdAndAmountOfOccurrances.Add(3, 1);
            var expectedCombinations = new[] { 3 }.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(21.6m);
        }

        [Fact]
        public void WhenCalculateFor5PercentButWithThreeBooks()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 2);
            bookIdAndAmountOfOccurrances.Add(2, 1);
            var expectedCombinations = new[] { 2, 1 }.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(23.2m);
        }

        [Fact]
        public void WhenCalculateFor20PercentDiscount()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 1);
            bookIdAndAmountOfOccurrances.Add(2, 1);
            bookIdAndAmountOfOccurrances.Add(3, 1);
            bookIdAndAmountOfOccurrances.Add(4, 1);
            var expectedCombinations = new[] { 4 }.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(25.6m);
        }

        [Fact]
        public void WhenCalculateFor25PercentDiscount()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 1);
            bookIdAndAmountOfOccurrances.Add(2, 1);
            bookIdAndAmountOfOccurrances.Add(3, 1);
            bookIdAndAmountOfOccurrances.Add(4, 1);
            bookIdAndAmountOfOccurrances.Add(5, 1);
            var expectedCombinations = new[] { 5 }.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(30m);
        }

        [Fact]
        public void WhenCalculateUsingExampleOnKata()
        {
            //Arrange
            var subject = Mocker.CreateInstance<CalculateDiscountedPrice>();
            var bookIdAndAmountOfOccurrances = new Dictionary<int, int>();
            bookIdAndAmountOfOccurrances.Add(1, 2);
            bookIdAndAmountOfOccurrances.Add(2, 2);
            bookIdAndAmountOfOccurrances.Add(3, 2);
            bookIdAndAmountOfOccurrances.Add(4, 1);
            bookIdAndAmountOfOccurrances.Add(5, 1);
            var expectedCombinations = new[] {4, 4}.ToList();
            Mocker.GetMock<IGetBookDiscountCombinations>().Setup(gbdc => gbdc.Get(bookIdAndAmountOfOccurrances))
                .Returns(expectedCombinations);
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(51.2m);
        }
    }
}
