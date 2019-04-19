using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Commands
{
    public class QuitCommand : ICommand
    {
        public QuitCommand(string text)
        {
            CommandText = text;
        }

        public string CommandText { get; }

        public void Run()
        {
            Environment.Exit(0);
        }
    }
}
