using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Models
{
    public class Robot : IRobot
    {
        private readonly Dictionary<Direction, (Direction left, Direction right)> _directions =
            new Dictionary<Direction, (Direction left, Direction right)>
            {
                {Direction.North, (Direction.West, Direction.East)},
                {Direction.East, (Direction.North, Direction.South)},
                {Direction.South, (Direction.East, Direction.West)},
                {Direction.West, (Direction.South, Direction.North)},
            };

        private readonly IRobotWarsGame _game;

        public Robot(IRobotWarsGame game, int x, int y, Direction direction)
        {
            _game = game;
            CoordinateY = y;
            CoordinateX = x;
            Direction = direction;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public Direction Direction { get; set; }

        public void Move(string command)
        {
            switch (command)
            {
                case "M":
                    MoveForward();
                    break;
                case "L":
                    TurnLeft();
                    break;
                case "R":
                    TurnRight();
                    break;
                default:
                    throw new Exception($"{command} is not a valid robot command");
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    CoordinateY = LimitValues(++CoordinateY, Axis.Y);
                    break;
                case Direction.East:
                    CoordinateX = LimitValues(++CoordinateX);
                    break;
                case Direction.South:
                    CoordinateY = LimitValues(--CoordinateY, Axis.Y);
                    break;
                case Direction.West:
                   CoordinateX = LimitValues(--CoordinateX);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            Direction = _directions[Direction].left;
        }

        private void TurnRight()
        {
            Direction = _directions[Direction].right;
        }

        private int LimitValues(int value, Axis axis = Axis.X)
        {
            if (value < 0)
            {
                return 0;
            }

            return Math.Min(value, axis == Axis.X ? _game.MaxX : _game.MaxY);
        }
    }
}
