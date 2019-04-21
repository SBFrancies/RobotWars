using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;
using Xunit;

namespace RobotWars.UnitTests.ModelTests
{
    public class RobotWarsGameTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<ILogger> _mockLogger = new Mock<ILogger>();
        private readonly List<IRobot> _robots = new List<IRobot>();

        public RobotWarsGameTests()
        {
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void CanAddRobots()
        {
            int count = _robots.Count;
            RobotWarsGame sut = CreateSystemUnderTest();

            sut.AddRobot(_fixture.Create<Robot>());

            Assert.Equal(++count, _robots.Count);

            sut.AddRobot(_fixture.Create<Robot>());

            Assert.Equal(++count, _robots.Count);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(2345)]
        [InlineData(100)]
        [InlineData(0)]
        public void LoggerCalledForEachRobot(int count)
        {
            IList<IRobot> robots = _fixture.CreateMany<IRobot>(count).ToList();
            RobotWarsGame sut = CreateSystemUnderTest(robots);

            sut.LogPositions();

            _mockLogger.Verify(a => a.LogMessage(It.IsAny<string>()), Times.Exactly(count));
        }

        [Fact]
        public void MoveLastRobotAdded()
        {
            IList<IRobot> robots = _fixture.CreateMany<IRobot>(5).ToList();
            Mock<IRobot> mockRobot = new Mock<IRobot>();
            robots.Add(mockRobot.Object);

            RobotWarsGame sut = CreateSystemUnderTest(robots);

            sut.MoveRobot("M");

            mockRobot.Verify(a => a.Move("M"), Times.Once);
        }

        public RobotWarsGame CreateSystemUnderTest(IList<IRobot> robots = null)
        {
            return new RobotWarsGame(_mockLogger.Object, robots ?? _robots);
        }
    }
}
