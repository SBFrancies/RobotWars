using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class QuitCommand : ICommand
    {
        public void Run(string commandText)
        {
            Environment.Exit(0);
        }
    }
}
