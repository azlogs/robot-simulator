# How to run project
### 1. Environment
- This project has built on .net 6, so make sure your pc has to install .net 6 befre run it. Refer here https://dotnet.microsoft.com/en-us/download/dotnet/6.0
### How to setup
1. Clone code
``````
    git clone https://github.com/azlogs/robot-simulator.git
``````
2. Open the terminal on the main project folder and run the command:
```````
    dotnet run
```````
It will run the test case that I defined in the command.txt file.
### Test cases
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
I added Expect after report easier to compare results between actual and expectations, the program will ignore the line if that is not a command.
The Invalid command  "PLACE x,y,F", "LEFT", "RIGHT", "MOVE", "REPORT"
x,y= number
F = "NORTH" | "SOUTH" | "WEST" | "EAST"
The invalid commands will be printed out on the screen
