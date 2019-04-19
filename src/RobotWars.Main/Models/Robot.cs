﻿using System;
using System.Collections.Generic;
using System.Text;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;

namespace RobotWars.Main.Models
{
    public class Robot : IRobot
    {
        private readonly IRobotWarsGame _game;

        public Robot(IRobotWarsGame game, int x, int y, Direction direction)
        {
            _game = game;
            CoordinateY = y;
            CoordinateX = x;
            Direction = direction;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public Direction Direction { get; set; }

        public void Move(ICommand command)
        {
            switch (command.CommandText)
            {
                case "M":
                    MoveForward();
                    break;
                case "L":
                    TurnLeft();
                    break;
                case "R":
                    TurnRight();
                    break;
                default:
                    throw new Exception($"{command.CommandText} is not a valid robot command");
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    CoordinateY = LimitValues(++CoordinateY, Axis.Y);
                    break;
                case Direction.East:
                    CoordinateX = LimitValues(++CoordinateY, Axis.Y);
                    break;
                case Direction.South:
                    CoordinateY = LimitValues(--CoordinateY, Axis.Y);
                    break;
                case Direction.West:
                   CoordinateX = LimitValues(--CoordinateY, Axis.Y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            Direction = (Direction)((int)--Direction % 4);
        }

        private void TurnRight()
        {
            Direction = (Direction)((int)++Direction % 4);
        }

        private int LimitValues(int value, Axis axis)
        {
            if (value < 0)
            {
                return 0;
            }

            return Math.Min(value, axis == Axis.X ? _game.MaxX : _game.MaxY);
        }
    }
}