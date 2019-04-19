using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Main.Interface
{
    public interface ILogger
    {
        void LogMessage(string message);

        void LogException(Exception exception);
    }
}
