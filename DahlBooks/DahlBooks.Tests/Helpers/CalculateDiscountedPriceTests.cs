using System;
using System.Collections.Generic;
using System.Text;
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
            //Act
            var result = subject.Calculate(bookIdAndAmountOfOccurrances);
            //Assert
            result.Should().Be(30m);
        }
    }
}
