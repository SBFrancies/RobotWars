using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;
using RobotWars.Main.Commands;
using RobotWars.Main.Interface;

namespace RobotWars.Main.CommandReaders
{
    public class StartGameCommandReader<T> : RegexCommandReader<T> where T : ICommand
    {
        public StartGameCommandReader(T command) : base(command, @"^\d+ \d+$")
        {
        }        
    }
}
