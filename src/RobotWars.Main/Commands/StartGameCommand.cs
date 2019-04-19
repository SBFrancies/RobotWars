using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;

namespace RobotWars.Main.Commands
{
    public class StartGameCommand : RobotWarsGameCommand
    {
        public StartGameCommand(IRobotWarsGame game) : base(game)
        {
        }

        public override void Run(string commandText)
        {
            string[] parts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _game.MaxX = Convert.ToInt32(parts[0]);
            _game.MaxY = Convert.ToInt32(parts[1]);
        }
    }
}
