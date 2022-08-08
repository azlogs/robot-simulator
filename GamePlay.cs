using Model;

namespace Toy
{
    internal static class GamePlay
    {
        const int DIMENSION = 5;
        private const string errorWrongCommand = "Wrong command";
        public static void StartGame(string[] inputCommands)
        {
            if (inputCommands == null || inputCommands.Length == 0)
            {
                Console.WriteLine("The input command is invalid");
                return;
            }

            // Create a Box
            var box = new Box(new Position(0, 0), new Position(DIMENSION, DIMENSION));
            // Create a robot
            var robot = new Robot();
            // Read a command
            foreach (var line in inputCommands)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    robot = new Robot();
                    continue;
                }
                var commandString = line.Trim();
                var staments = commandString.Split(" ");
                // is not an action
                if (!Enum.TryParse(staments[0], false, out Commands command))
                {
                    Console.WriteLine(commandString);
                    Console.WriteLine("-------------------");
                    continue;
                }

                var currentPosition = new Position(robot.CurrentPosition);
                try
                {
                    // validate place command
                    Position? position = null;
                    Directions? direction = null;
                    if (staments.Count() == 2 && staments[0] == Commands.PLACE.ToString())
                    {
                        var placeCommands = staments[1].Split(",");
                        if (placeCommands.Length != 3)
                        {
                            throw new ArgumentException($"{errorWrongCommand} at place \"{staments[1]}\"");
                        }
                        position = GetPosition(placeCommands[0], placeCommands[1]);
                        direction = GetDirection(placeCommands[2]);
                    }
                    else if (staments.Count() != 1)
                    {
                        robot.Stop();
                        throw new ArgumentException($"{errorWrongCommand} at place \"{commandString}\"");
                    }

                    robot.TakeAnAction(command, position, direction);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Actual: {ex.Message}");
                }

                // check robot out of box
                if (command == Commands.MOVE && !box.IsInBox(robot.CurrentPosition))
                {
                    robot.CurrentPosition = currentPosition;
                }
            }
        }

        static Position GetPosition(string xstring, string yString)
        {
            if (!int.TryParse(xstring, out int x))
            {
                throw new ArgumentException($"{errorWrongCommand} at position X \"{xstring}\"");
            }
            if (!int.TryParse(yString, out int y))
            {
                throw new ArgumentException($"{errorWrongCommand} at position Y \"{yString}\"");
            }

            return new Position(x, y);
        }

        static Directions GetDirection(string directionString)
        {
            if (!Enum.TryParse(directionString, false, out Directions direction))
            {
                throw new ArgumentException($"{errorWrongCommand} at direction \"{directionString}\"");
            }

            return direction;
        }
    }
}