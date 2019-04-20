using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandReaderTests
{
    public class MoveRobotCommandReaderTests
    {
        private readonly Mock<ICommand> _mockCommand = new Mock<ICommand>();

        [Theory]
        [InlineData("")]
        [InlineData("MLRMLRMLRMLRD")]
        [InlineData("qwertyuiop")]
        [InlineData("TYPWMWEL")]
        [InlineData("3 3 3 N")]
        public void CommandShouldNotRunWhenInputDoesNotMatchRegex(string input)
        {
            MoveRobotCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Never);
        }

        [Theory]
        [InlineData("M")]
        [InlineData("MLRMLRMLRMLRMLRmlrmlrmlr")]
        [InlineData("RRRRRRRR")]
        [InlineData("lllllllllMMMMR")]
        [InlineData("Mlr")]
        public void CommandShouldRunWhenInputDoesMatchRegex(string input)
        {
            MoveRobotCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Once);
        }

        private MoveRobotCommandReader<ICommand> CreateSystemUnderTest()
        {
            return new MoveRobotCommandReader<ICommand>(_mockCommand.Object);
        }
    }
}
