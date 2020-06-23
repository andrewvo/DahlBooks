using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using DahlBooks.Controllers;
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
            var books = AutoFixture.Create<int[]>();

            //Act
            var result = subject.Get(books);

            //Assert
            result.Should().BeGreaterThan(0.00m);
        }
    }
}
