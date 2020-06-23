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
        public void WhenCalculate()
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
    }
}
