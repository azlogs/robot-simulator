namespace Model
{
    internal class Robot
    {
        public Position? CurrentPosition { get; set; }
        public Directions? CurrentDirection { get; set; }
        private bool isRobotActivate { get; set; }

        public void TakeAnAction(Commands command, Position? position, Directions? direction)
        {
            if (!isRobotActivate && command != Commands.PLACE)
            {
                Console.WriteLine($"The Robot is not ready yet");
                return;
            }

            switch (command)
            {
                case Commands.PLACE:
                    CurrentPosition = new Position(position);
                    CurrentDirection = direction;
                    isRobotActivate = true;
                    break;
                case Commands.MOVE:
                    move();
                    break;
                case Commands.LEFT:
                case Commands.RIGHT:
                    turn(command);
                    break;
                case Commands.REPORT:
                    Console.WriteLine($"Actual: {this}");
                    break;
                default:
                    break;
            }
        }

        public void Stop(){
            isRobotActivate = false;
        }

        // override
        public override string ToString()
        {
            if (CurrentPosition == null)
            {
                return "Undefined";
            }

            return $"{CurrentPosition},{CurrentDirection.ToString()}";
        }

        // Private functions
        private void turn(Commands command)
        {
            if (CurrentDirection == null)
            {
                throw new ArgumentException("You haven't set the direction yet");
            }
            if (command != Commands.LEFT && command != Commands.RIGHT)
            {
                return;
            }

            int currentDirectionIndex = (int)CurrentDirection;

            var nextIndex = currentDirectionIndex;
            if (command == Commands.LEFT)
            {
                nextIndex = currentDirectionIndex - 1;
            }
            else if (command == Commands.RIGHT)
            {
                nextIndex = currentDirectionIndex + 1;
            }

            if (nextIndex > 4)
            {
                nextIndex = 1;
            }

            if (nextIndex < 1)
            {
                nextIndex = 4;
            }

            CurrentDirection = (Directions)nextIndex;
        }

        private void move()
        {
            if (CurrentPosition == null)
            {
                throw new ArgumentException("You haven't set the position yet");
            }
            /*
                    S 2
                    |
                    |
            E 1 ----(0,0)----------> E 3, X
                    |
                    |  Robot(x, y)
                    |
                    |
                    \/
                    N 4, Y
            */
            if (CurrentDirection == Directions.SOUTH)
            {
                CurrentPosition.Y -= 1;
            }
            else if (CurrentDirection == Directions.NORTH)
            {
                CurrentPosition.Y += 1;
            }
            else if (CurrentDirection == Directions.EAST)
            {
                CurrentPosition.X += 1;
            }
            else if (CurrentDirection == Directions.WEST)
            {
                CurrentPosition.X -= 1;
            }
        }
    }
}