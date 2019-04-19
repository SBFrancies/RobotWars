using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class MoveRobotCommand : RobotWarsGameCommand
    {
        public MoveRobotCommand(IRobotWarsGame game, string text) : base(game, text)
        {
        }

        public override void Run()
        {
            foreach (char command in CommandText.ToCharArray())
            {
                _game.MoveRobot(new RobotCommand(command));
            }
        }
    }
}
