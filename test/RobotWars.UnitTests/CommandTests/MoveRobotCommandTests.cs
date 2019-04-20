using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using RobotWars.Main.Commands;
using RobotWars.Main.Interface;
using Xunit;

namespace RobotWars.UnitTests.CommandTests
{
    public class MoveRobotCommandTests
    {
        private readonly Mock<IRobotWarsGame> _mockGame = new Mock<IRobotWarsGame>();

        [Theory]
        [InlineData("MMMRMR")]
        [InlineData("L")]
        [InlineData("MMMMMMMMMMLLLLLLLLRMLRMLRMRLRM")]
        [InlineData("")]
        public void RunningCallsMoveRobot(string input)
        {
            MoveRobotCommand sut = CreateSystemUnderTest();

            sut.Run(input);

            _mockGame.Verify(a => a.MoveRobot(It.IsAny<string>()), Times.Exactly(input.Length));
        }


        private MoveRobotCommand CreateSystemUnderTest()
        {
            return new MoveRobotCommand(_mockGame.Object);
        }
    }
}
