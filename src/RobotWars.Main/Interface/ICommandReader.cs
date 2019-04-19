using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RobotWars.Main.Interface
{
    public interface ICommandReader
    {
        void ValidateAndRun(string commandText);
    }
}
