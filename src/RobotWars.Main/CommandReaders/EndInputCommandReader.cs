using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;

namespace RobotWars.Main.CommandReaders
{
    public class EndInputCommandReader : RegexCommandReader
    {
        public EndInputCommandReader() : base(@"^$")
        {
        }
    }
}
