using System;
using System.Collections.Generic;
using System.Text;
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
            var numberOfOccurances = AutoFixture.Create<Dictionary<int,int>>();
            var books = AutoFixture.Create<int[]>();
            var discountedPrice = AutoFixture.Create<decimal>();
            Mocker.GetMock<IGroupNumbersByOccurences>().Setup(gnbo => gnbo.Group(books)).Returns(numberOfOccurances);
            Mocker.GetMock<ICalculateDiscountedPrice>().Setup(cdp => cdp.Calculate(numberOfOccurances))
                .Returns(discountedPrice);
            //Act
            var result = subject.GetPrice(books);
            //Assert
            result.Should().Be(discountedPrice);
        }
    }
}
