using System.Collections.Generic;
using AutoFixture;
using DahlBooks.Helpers;
using DahlBooks.Service;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace DahlBooks.Tests.Service
{
    public class PriceCalculatorServiceTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public PriceCalculatorServiceTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGet()
        {
            //Arrange
            var subject = Mocker.CreateInstance<PriceCalculatorService>();
            var numberOfOccurences = AutoFixture.Create<Dictionary<int, int>>();
            var books = AutoFixture.Create<int[]>();
            var discountedPrice = AutoFixture.Create<decimal>();
            Mocker.GetMock<IGroupNumbersByOccurrences>().Setup(gnbo => gnbo.Group(books)).Returns(numberOfOccurences);
            Mocker.GetMock<ICalculateDiscountedPrice>().Setup(cdp => cdp.Calculate(numberOfOccurences))
                .Returns(discountedPrice);
            //Act
            var result = subject.GetPrice(books);
            //Assert
            result.Should().Be(discountedPrice);
        }
    }
}