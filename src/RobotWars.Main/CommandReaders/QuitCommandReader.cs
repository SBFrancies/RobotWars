using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Command;
using RobotWars.Main.Interface;

namespace RobotWars.Main.CommandReaders
{
    public class QuitCommandReader<T> : RegexCommandReader<T> where T : ICommand
    {
        public QuitCommandReader(T command) : base(command, "quit", RegexOptions.IgnoreCase)
        {
        }
    }
}
