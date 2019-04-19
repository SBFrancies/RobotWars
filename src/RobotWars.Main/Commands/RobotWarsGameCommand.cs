using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public abstract class RobotWarsGameCommand : ICommand
    {
        protected readonly IRobotWarsGame _game;

        protected RobotWarsGameCommand(IRobotWarsGame game)
        {
            _game = game;
        }

        public abstract void Run(string commandText);
    }
}
