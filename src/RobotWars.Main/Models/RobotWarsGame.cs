﻿using System;
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

        public RobotWarsGame(ILogger logger, IList<IRobot> robots)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _robots = robots ?? throw new ArgumentNullException(nameof(robots));
        }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public void AddRobot(IRobot robot )
        {
            _robots.Add(FitRobotPosition(robot));
        }

        public void MoveRobot(string command)
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

        private IRobot FitRobotPosition(IRobot robot)
        {
            robot.CoordinateX = Math.Min(robot.CoordinateX, MaxX);
            robot.CoordinateY = Math.Min(robot.CoordinateY, MaxY);

            return robot;
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
