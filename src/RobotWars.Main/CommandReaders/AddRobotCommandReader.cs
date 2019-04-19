using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;
using RobotWars.Main.Interface;

namespace RobotWars.Main.CommandReaders
{
    public class AddRobotCommandReader<T>: RegexCommandReader<T> where T : ICommand
    {
        public AddRobotCommandReader(T command) : base(command, @"^\d+ \d+ (n|e|s|w)$", RegexOptions.IgnoreCase)
        {
        }
    }
}
