# Requirement
- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
- Create an application that can read in commands of the following form -
- PLACE X,Y,F
    - MOVE
    - LEFT
    - RIGHT
    -  REPORT
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
- The origin (0,0) can be considered to be the SOUTH WEST most corner.
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position
of the robot.
- REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
- A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.
- Input can be from a file, or from command line input, as the developer chooses.
- Provide test data to demonstrate the application in operation. (file input commands.txt)
## CONSTRAINTS
- The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Any move that would cause the robot to fall must be ignored.
# EXAMPLE 1
Input:
    PLACE 0,0,NORTH
    MOVE
    REPORT
Example Output:
    0,1,NORTH
EXAMPLE 2
Input:
    PLACE 0,0,NORTH
    LEFT
    REPORT
Output:
    0,0,WEST
    
# How to use project
### 1. Environment
- This project has built on .net 6, so make sure your pc has to install .net 6 befre run it. Refer here https://dotnet.microsoft.com/en-us/download/dotnet/6.0
### 2. How to run
1. Clone code
``````
    git clone https://github.com/azlogs/robot-simulator.git
``````
2. Open the terminal on the main project folder and run the command:
```````
    dotnet run
```````
It will run the test case that I defined in the command.txt file.
### 3. Test cases
1. Change the test case

The project reads the test case in the "command. text" file in the main project folder.
if you want to change the test cases you can modify this file. Or if you want to use another file, please change the path in the "Program. cs" file, make sure the path is right
```
     const string INPUT_FILE = "command.txt"; // change the file name here
    //... 
    string currentDirectory = Directory.GetCurrentDirectory();
    string COMMAND_FILE_PATH = $"{currentDirectory}/{INPUT_FILE}";
    inputCommands = FileHelper.ReadFile(COMMAND_FILE_PATH); // or you can change the file path here
    //...
```
2. Test case format
The test case formation is follows the example below, the break line is used to separate the test cases
````
PLACE 0,0,NORTH
MOVE
REPORT
Expect: 0,1,NORTH

PLACE 0,0,NORTH
LEFT
REPORT
Expect: 0,0,WEST
````
I added an expectation after the "REPORT" command for easier to compare results between actual and expectations, the program will ignore the line if that is not a command.

The Invalid command  
```
"PLACE x,y,F", "LEFT", "RIGHT", "MOVE", "REPORT"
x,y= number
F = "NORTH" | "SOUTH" | "WEST" | "EAST"
```
The invalid commands will be printed out on the screen
