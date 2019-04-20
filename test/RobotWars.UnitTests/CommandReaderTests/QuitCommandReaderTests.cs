using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandReaderTests
{
    public class QuitCommandReaderTests
    {
        private readonly Mock<ICommand> _mockCommand = new Mock<ICommand>();

        [Theory]
        [InlineData("")]
        [InlineData("EXIT")]
        [InlineData("quitt")]
        [InlineData("q")]
        [InlineData("end")]
        public void CommandShouldNotRunWhenInputDoesNotMatchaRegex(string input)
        {
            QuitCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Never);
        }

        [Theory]
        [InlineData("quit")]
        [InlineData("QUIT")]
        [InlineData("qUiT")]
        [InlineData("quIT")]
        [InlineData("QUit")]
        public void CommandShouldRunWhenInputDoesMatchRegex(string input)
        {
            QuitCommandReader<ICommand> sut = CreateSystemUnderTest();

            sut.ValidateAndRun(input);

            _mockCommand.Verify(a => a.Run(input), Times.Once);
        }

        private QuitCommandReader<ICommand> CreateSystemUnderTest()
        {
            return new QuitCommandReader<ICommand>(_mockCommand.Object);
        }
    }
}
