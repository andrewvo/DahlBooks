﻿using AutoFixture;
using DahlBooks.Controllers;
using DahlBooks.Service;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace DahlBooks.Tests.Controllers
{
    public class PriceCalculatorControllerTests
    {
        public Fixture AutoFixture { get; set; }
        public AutoMocker Mocker { get; set; }

        public PriceCalculatorControllerTests()
        {
            AutoFixture = new Fixture();
            Mocker = new AutoMocker();
        }

        [Fact]
        public void WhenGet()
        {
            //Arrange
            var subject = Mocker.CreateInstance<PriceCalculatorController>();
            var books = AutoFixture.Create<Books>();
            var price = AutoFixture.Create<decimal>();
            Mocker.GetMock<IPriceCalculatorService>().Setup(srv => srv.GetPrice(books.Ids)).Returns(price);
            //Act
            var result = subject.Get(books);

            //Assert
            result.Should().Be(price);
        }
    }
}