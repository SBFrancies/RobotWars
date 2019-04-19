using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;

namespace RobotWars.Main.CommandReaders
{
    public class AddRobotCommandReader : RegexCommandReader
    {
        public AddRobotCommandReader() : base(@"^\d+ \d+ (n|e|s|w)$", RegexOptions.IgnoreCase)
        {
        }
    }
}
