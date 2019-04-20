using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandReaderTests
{
    public class StartGameCommandReaderTests
    {
        private readonly Mock<ICommand> _mockCommand = new Mock<ICommand>();

        [Theory]
        [InlineData("12131 45 a")]
        [InlineData("qwertyuiop")]
        [InlineData("")]
        [InlineData("not correct")]
        [InlineData("3 3 N")]
        public void CommandShouldNotRunWhenInputDoesNotMatchRgex(string input)
        {
            StartGameCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Never);
        }

        [Theory]
        [InlineData("5 5")]
        [InlineData("10 5878")]
        [InlineData("12 0")]
        [InlineData("345678 87")]
        [InlineData("100 4")]
        public void CommandShouldRunWhenInputDoesMatchRgex(string input)
        {
            StartGameCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Once);
        }

        private StartGameCommandReader<ICommand> CreateSystemUnderTest()
        {
            return new StartGameCommandReader<ICommand>(_mockCommand.Object);
        }
    }
}
