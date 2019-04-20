using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.Commands;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;
using Xunit;

namespace RobotWars.UnitTests.CommandTests
{
    public class EndInputCommandTests
    {
        private readonly Mock<IRobotWarsGame> _mockGame = new Mock<IRobotWarsGame>();

        [Fact]
        public void DoesCallGameLoggingMethodOnRun()
        {
            EndInputCommand sut = CreateSystemUnderTest();

            sut.Run(It.IsAny<string>());

            _mockGame.Verify(a => a.LogPositions(), Times.Once);
        }

        private EndInputCommand CreateSystemUnderTest()
        {
            return new EndInputCommand(_mockGame.Object);
        }
    }
}
