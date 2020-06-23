using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
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
        public void WhenGetTwoDifferentBooks()
        {
            //Arrange
            var subject = new PriceCalculatorService();
            var books = new[] {1,2,1};
            //Act
            var result = subject.GetPrice(books);
            //Assert
            result.Should().Be(23.2m);
        }
    }
}
