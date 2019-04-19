using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars.Main.Interface
{
    public interface IRobotWarsGame
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
        
        void AddRobot(IRobot robot);
        void MoveRobot(string command);
        void LogPositions();
    }
}
