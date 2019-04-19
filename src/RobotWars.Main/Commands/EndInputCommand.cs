using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class EndInputCommand : RobotWarsGameCommand
    {
        public EndInputCommand(IRobotWarsGame game, string text) : base(game, text)
        {
        }

        public override void Run()
        {
            _game.LogPositions();
        }
    }
}
