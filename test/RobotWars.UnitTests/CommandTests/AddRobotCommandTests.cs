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
    public class AddRobotCommandTests
    {
        private readonly Mock<IRobotWarsGame> _mockGame = new Mock<IRobotWarsGame>();
        private readonly Mock<Func<IRobotWarsGame, int, int, Direction, IRobot>> _mockFactory = new Mock<Func<IRobotWarsGame, int, int, Direction, IRobot>>();

        [Theory]
        [InlineData("1 0 E")]
        [InlineData("10 2 N")]
        [InlineData("1213 32 W")]
        [InlineData("12 12 S")]
        public void AddsRobotWhenCorrectlyFormattedStringEnetered(string input)
        {
            AddRobotCommand sut = CreateSystemUnderTest();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int x = Convert.ToInt32(parts[0]);
            int y = Convert.ToInt32(parts[1]);
            Direction direction = ConvertToDirection(parts[2]);

            sut.Run(input);

            _mockFactory.Verify(a => a(_mockGame.Object, x, y, direction), Times.Once);
            _mockGame.Verify(a => a.AddRobot(It.IsAny<IRobot>()), Times.Once);
        }

        [Theory]
        [InlineData("1 0 T")]
        [InlineData("10 2 5678 N")]
        [InlineData("1213 32 WEST")]
        [InlineData("wrong")]
        public void CanThrowExceptionOnInvalidInput(string input)
        {
            AddRobotCommand sut = CreateSystemUnderTest();

            Assert.ThrowsAny<Exception>(() => sut.Run(input));
        }

        private AddRobotCommand CreateSystemUnderTest()
        {
            return new AddRobotCommand(_mockGame.Object, _mockFactory.Object);
        }

        private Direction ConvertToDirection(string input)
        {
            switch (input.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input), input, null);
            }
        }
    }
}
