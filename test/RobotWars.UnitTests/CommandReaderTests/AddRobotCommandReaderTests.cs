using RobotWars.Main.CommandReaders;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandReaderTests
{
    public class AddRobotCommandReaderTests
    {
        private readonly Mock<ICommand> _mockCommand = new Mock<ICommand>();

        [Theory]
        [InlineData("3 3 G")]
        [InlineData("qwertyuiop")]
        [InlineData("")]
        [InlineData("not correct")]
        [InlineData("3 3 3 N")]
        public void CommandShouldNotRunWhenInputDoesNotMatchRegex(string input)
        {
            AddRobotCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Never);
        }

        [Theory]
        [InlineData("0 0 N")]
        [InlineData("10 5 S")]
        [InlineData("12 0 E")]
        [InlineData("345678 87 W")]
        [InlineData("0 45 S")]
        public void CommandShouldRunWhenInputDoesMatchRegex(string input)
        {
            AddRobotCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Once);
        }

        private AddRobotCommandReader<ICommand> CreateSystemUnderTest()
        {
            return new AddRobotCommandReader<ICommand>(_mockCommand.Object);
        }
    }
}
