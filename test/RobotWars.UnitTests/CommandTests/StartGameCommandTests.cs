using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.Commands;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandTests
{
    public class StartGameCommandTests
    {
        private readonly Mock<IRobotWarsGame> _mockGame = new Mock<IRobotWarsGame>();

        [Theory]
        [InlineData("1 1")]
        [InlineData("10 3434")]
        [InlineData("1213 32")]
        [InlineData("12 12")]
        public void AddsRobotWhenCorrectlyFormattedStringEnetered(string input)
        {
            StartGameCommand sut = CreateSystemUnderTest();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int maxX = Convert.ToInt32(parts[0]);
            int maxY = Convert.ToInt32(parts[1]);

            sut.Run(input);

            _mockGame.VerifySet(a => a.MaxX = maxX, Times.Once());
            _mockGame.VerifySet(a => a.MaxY = maxY, Times.Once());
        }

        [Theory]
        [InlineData("1 T")]
        [InlineData("")]
        [InlineData("1213 32WEST")]
        [InlineData("wrong")]
        public void CanThrowExceptionOnInvalidInput(string input)
        {
            StartGameCommand sut = CreateSystemUnderTest();

            Assert.ThrowsAny<Exception>(() => sut.Run(input));
        }

        private StartGameCommand CreateSystemUnderTest()
        {
            return new StartGameCommand(_mockGame.Object);
        }
    }
}
