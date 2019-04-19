using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RobotWars.Main.Enums;

namespace RobotWars.Main.Interface
{
    public interface IRobot
    {
        void Move(ICommand command);

        int CoordinateX { get; set; }

        int CoordinateY { get; set; }

        Direction Direction { get; set; }
    }
}
