using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;
using RobotWars.Main.Interface;

namespace RobotWars.Main.CommandReaders
{
    public class MoveRobotCommandReader<T> : RegexCommandReader<T> where T : ICommand
    {
        public MoveRobotCommandReader(T command) : base(command, @"^(m|l|r)+$", RegexOptions.IgnoreCase)
        {
        }
    }
}
