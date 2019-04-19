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
        public AddRobotCommand(IRobotWarsGame game, string text) : base(game, text)
        {
        }

        public override void Run()
        {
            string[] parts = CommandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Robot robot = new Robot(
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
