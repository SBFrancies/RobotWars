using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void LogException(Exception exception)
        {
            while (exception != null)
            {
                Console.WriteLine(exception.Message);
                exception = exception.InnerException;
            }
        }
    }
}
