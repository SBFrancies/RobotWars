using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public abstract class RobotWarsGameCommand : ICommand
    {
        protected readonly IRobotWarsGame _game;

        protected RobotWarsGameCommand(IRobotWarsGame game, string text)
        {
            _game = game;
            CommandText = text;
        }

        public string CommandText { get; }

        public abstract void Run();
    }
}
