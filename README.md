# RobotWars

## Description
A small Console application to allow users to move robots around a game board. The project has been built using .Net Core 2.2.

## Requirements to run

1) .Net Core 2.2

## Projects

### RobotWars.Main

This project contains the code the the game.

### RobotWars.UnitTests

This project contains the unit tests.

## Instructions

1) Run the console application

2) To set up a game board enter the maximum X and Y coordinates in the format "maxX maxY"

3) To add a robot enter its initial cooridnates and the direction it is facing (N, E, S or W) in the format "x y direction"

4) To move the most recently added robot enter a command string containing only the characters "M", "L" and "R"

5) After you have finished robots enter a blank space to log the position of the robots after the entered movements

Example input:

5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM 

Example output:

1 3 N
5 1 E 

## Notes

1) It is not possible to place a robot outside of the game grid, its inital values will be truncated to the maximum/minimum extent of the grid if neccessary

2) A robot cannot move outside the grid, if instructed to it will simply not move

## If I had more time / Future changes

1) Add StyleCop or some other static code analysis tool

2) Create a UI for entering the robot details and viewing the game board

3) Have a penalty system for if the robots attempt to move outside the grid or collide

4) Allow the robots to move in turn rather than consecutively

## Credits

Thanks to John Nye (ninjanye) for some inspiration relating to design patterns in their similar project: https://github.com/ninjanye/RobotWars

