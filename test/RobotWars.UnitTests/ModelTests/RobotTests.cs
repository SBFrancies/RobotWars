using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Moq;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;
using Xunit;

namespace RobotWars.UnitTests.ModelTests
{
    public class RobotTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<IRobotWarsGame> _mockGame = new Mock<IRobotWarsGame>();

        public RobotTests()
        {
            _mockGame.SetupGet(a => a.MaxX).Returns(2);
            _mockGame.SetupGet(a => a.MaxY).Returns(2);
        }

        [Fact]
        public void RobotTurnsLeftFromNorthToWest()
        {
            Robot sut = CreateSystemUnderTest();
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;
            sut.Direction = Direction.North;

            sut.Move("L");

            Assert.Equal(Direction.West, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsRightFromNorthToEast()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.North;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("R");

            Assert.Equal(Direction.East, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsLeftFromEastToNorth()
        {
            Robot sut = CreateSystemUnderTest();
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;
            sut.Direction = Direction.East;

            sut.Move("L");

            Assert.Equal(Direction.North, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsRightFromEastToSouth()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.East;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("R");

            Assert.Equal(Direction.South, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsLeftFromSouthToEast()
        {
            Robot sut = CreateSystemUnderTest();
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;
            sut.Direction = Direction.South;

            sut.Move("L");

            Assert.Equal(Direction.East, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsRightFromSouthToWest()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.South;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("R");

            Assert.Equal(Direction.West, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsLeftFromWestToSouth()
        {
            Robot sut = CreateSystemUnderTest();
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;
            sut.Direction = Direction.West;

            sut.Move("L");

            Assert.Equal(Direction.South, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void RobotTurnsRightFromWestToNorth()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.West;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("R");

            Assert.Equal(Direction.North
, sut.Direction);
            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
        }

        [Fact]
        public void YCoordinateIncrementsUpWhenMovingNorth()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.North;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("M");

            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(++y, sut.CoordinateY);
            Assert.Equal(Direction.North, sut.Direction);
        }

        [Fact]
        public void YCoordinateIncrementsDownWhenMovingSouth()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.South;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("M");

            Assert.Equal(x, sut.CoordinateX);
            Assert.Equal(--y, sut.CoordinateY);
            Assert.Equal(Direction.South, sut.Direction);
        }

        [Fact]
        public void XCoordinateIncrementsUpWhenMovingEast()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.East;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("M");

            Assert.Equal(++x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
            Assert.Equal(Direction.East, sut.Direction);
        }

        [Fact]
        public void XCoordinateIncrementsDownWhenMovingWest()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.West;
            int x = sut.CoordinateX;
            int y = sut.CoordinateY;

            sut.Move("M");

            Assert.Equal(--x, sut.CoordinateX);
            Assert.Equal(y, sut.CoordinateY);
            Assert.Equal(Direction.West, sut.Direction);
        }

        [Fact]
        public void RobotCannotMoveOutOfGameField()
        {
            Robot sut = CreateSystemUnderTest();
            sut.Direction = Direction.North;
            sut.CoordinateX = _mockGame.Object.MaxX;
            sut.CoordinateY = _mockGame.Object.MaxY;

            sut.Move("M");

            Assert.Equal(_mockGame.Object.MaxY, sut.CoordinateY);

            sut.Move("R");
            sut.Move("M");

            Assert.Equal(_mockGame.Object.MaxX, sut.CoordinateX);
        }

        private Robot CreateSystemUnderTest()
        {
            return new Robot(
                _mockGame.Object,
                1,
                1,
                _fixture.Create<Direction>());
        }
    }
}
