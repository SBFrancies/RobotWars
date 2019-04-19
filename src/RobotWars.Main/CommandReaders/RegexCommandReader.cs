using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Command
{
    public abstract class RegexCommandReader: ICommandReader
    {
        private readonly Regex _regex;

        protected RegexCommandReader(string pattern, RegexOptions options = RegexOptions.None)
        {
            _regex = new Regex(pattern, options);
        }

        public void ValidateAndRun(ICommand command)
        {
            if (_regex.IsMatch(command.CommandText))
            {
                command.Run();
            }
        }
    }
}
