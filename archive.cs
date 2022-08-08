/*
const string INPUT_FILE = "command.txt";
string currentDirectory = Directory.GetCurrentDirectory();
string COMMAND_FILE_PATH = $"{currentDirectory}/{INPUT_FILE}";
var SOUTH = "SOUTH";
var NORTH = "NORTH";
var EAST = "EAST";
var WEST = "WEST";
var DIRECTIONS = new string[] { "SOUTH", "WEST", "NORTH", "EAST" };
var direction = "";
var currentPosition = new Position(0, 0);
const int DIMENSION = 5;

string[] ReadFile(string path)
{
    return File.ReadAllLines(path);
}

string[] input = ReadFile(COMMAND_FILE_PATH);

string GetNextDirection(Actions action, string direction)
{
    var index = Array.IndexOf(DIRECTIONS, direction);
    var nextIndex = index;

    if (action == Actions.LEFT)
    {
        nextIndex = index - 1;
    }
    else if (action == Actions.RIGHT)
    {
        nextIndex = index + 1;
    }

    if (index == 4)
    {
        nextIndex = 0;
    }

    return DIRECTIONS[nextIndex];
}

int getNextvalue(int currentValue, int additional)
{
    int nextValue = currentValue + additional;
    if (nextValue < 0) return 0;
    if (nextValue > DIMENSION) return DIMENSION;
    return nextValue;
}

foreach (var line in input)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        continue;
    }

    var staments = line.Split(" ");

    // is not an action
    if (!Enum.TryParse(typeof(Actions), staments[0], out var command))
    {
        Console.WriteLine(line);
        continue;
    }

    switch (command)
    {
        case Actions.PLACE:
            var positionString = staments[1].Split(",");
            // get s, w
            int s = int.Parse(positionString[0]);
            int w = int.Parse(positionString[1]);
            currentPosition = new Position(s, w);
            direction = positionString[2];
            break;
        case Actions.MOVE:
            if (direction == "")
            {
                break;
            }
            if (direction == SOUTH)
            {
                currentPosition.Y = getNextvalue(currentPosition.X, -1);
            }
            else if (direction == NORTH)
            {
                currentPosition.Y = getNextvalue(currentPosition.X, 1);
            }
            else if (direction == EAST)
            {
                currentPosition.X = getNextvalue(currentPosition.X, 1);
            }
            else if (direction == WEST)
            {
                currentPosition.X = getNextvalue(currentPosition.X, -1);
            }
            break;
        case Actions.LEFT:
            direction = GetNextDirection(Actions.LEFT, direction);
            break;
        case Actions.RIGHT:
            direction = GetNextDirection(Actions.RIGHT, direction);
            break;
        case Actions.REPORT:
            Console.WriteLine($"Actual: {currentPosition},{direction}");
            break;
        default:
            //Console.WriteLine(line);
            break;
    }
}

enum Actions
{
    PLACE,
    MOVE,
    LEFT,
    RIGHT,
    REPORT,
};

class Position
{
    public int X;
    public int Y;
    public Position() { }
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}
*/