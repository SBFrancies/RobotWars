using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandReaderTests
{
    public class EndInputCommandReaderTests
    {
        private readonly Mock<ICommand> _mockCommand = new Mock<ICommand>();

        [Theory]
        [InlineData("    ")]
        [InlineData("qwertyuiop")]
        [InlineData(" ")]
        [InlineData("not correct")]
        [InlineData("-")]
        public void CommandShouldNotRunWhenInputDoesNotMatchRegex(string input)
        {
            EndInputCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Never);
        }

        [Theory]
        [InlineData("")]
        public void CommandShouldRunWhenInputDoesMatchRegex(string input)
        {
            EndInputCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Once);
        }

        private EndInputCommandReader<ICommand> CreateSystemUnderTest()
        {
            return new EndInputCommandReader<ICommand>(_mockCommand.Object);
        }
    }
}
