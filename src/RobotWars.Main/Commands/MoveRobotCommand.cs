using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class MoveRobotCommand : RobotWarsGameCommand
    {
        public MoveRobotCommand(IRobotWarsGame game) : base(game)
        {
        }

        public override void Run(string commandText)
        {
            foreach (char command in commandText)
            {
                _game.MoveRobot(command.ToString());
            }
        }
    }
}
