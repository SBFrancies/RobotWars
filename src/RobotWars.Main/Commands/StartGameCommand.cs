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
        public StartGameCommand(IRobotWarsGame game, string text) : base(game, text)
        {
        }

        public override void Run()
        {
            string[] parts = CommandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            _game.MaxX = Convert.ToInt32(parts[0]);
            _game.MaxY = Convert.ToInt32(parts[1]);
        }
    }
}
