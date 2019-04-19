using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class EndInputCommand : RobotWarsGameCommand
    {
        public EndInputCommand(IRobotWarsGame game) : base(game)
        {
        }

        public override void Run(string commandText)
        {
            _game.LogPositions();
        }
    }
}
