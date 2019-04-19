using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Command
{
    public abstract class RegexCommandReader<T>: ICommandReader where T: ICommand
    {
        private readonly Regex _regex;
        private readonly ICommand _command;

        protected RegexCommandReader(T command, string pattern, RegexOptions options = RegexOptions.None)
        {
            _regex = new Regex(pattern, options);
            _command = command;
        }

        public void ValidateAndRun(string commandText)
        {
            if (_regex.IsMatch(commandText))
            {
                _command.Run(commandText);
            }
        }
    }
}
