using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Interface;
using RobotWars.Main.Models;

namespace RobotWars.Main.Commands
{
    public class RobotCommand : ICommand
    {
        public RobotCommand(char command)
        {
            CommandText = command.ToString();
        }

        public string CommandText { get; }

        public void Run()
        {
        }
    }
}
