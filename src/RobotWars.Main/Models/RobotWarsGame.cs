using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Models
{
    public class RobotWarsGame : IRobotWarsGame
    {
        private readonly ILogger _logger;
        private readonly IList<IRobot> _robots;

        public RobotWarsGame(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _robots = new List<IRobot>();
        }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public void AddRobot(IRobot robot )
        {
            _robots.Add(robot);
        }

        public void MoveRobot(ICommand command)
        {
            _robots.LastOrDefault()?.Move(command);
        }

        public void LogPositions()
        {
            foreach (IRobot robot in _robots)
            {
                _logger.LogMessage($"{robot.CoordinateX} {robot.CoordinateY} {PrintDirection(robot.Direction)}");
            }
        }

        private char PrintDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return 'N';
                case Direction.East:
                    return 'E';
                case Direction.South:
                    return 'S';
                case Direction.West:
                    return 'W';
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
