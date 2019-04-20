using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;

namespace RobotWars.Main.Commands
{
    public class AddRobotCommand : RobotWarsGameCommand
    {
        private readonly Func<IRobotWarsGame, int, int, Direction, IRobot> _robotFactory;

        public AddRobotCommand(IRobotWarsGame game, Func<IRobotWarsGame, int, int, Direction, IRobot> robotFactory) : base(game)
        {
            _robotFactory = robotFactory;
        }

        public override void Run(string commandText)
        {
            string[] parts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IRobot robot = _robotFactory(
                _game,
                Convert.ToInt32(parts[0]),
                Convert.ToInt32(parts[1]),
                ConvertToDirection(parts[2]));

            _game.AddRobot(robot);
        }

        private Direction ConvertToDirection(string input)
        {
            switch (input.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input), input, null);
            }
        }
    }
}
