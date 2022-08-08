namespace Model
{
    class Box
    {
        public Position MaxPosition { get; set; }
        public Position MinPosition { get; set; }

        public Box(Position minPosition, Position maxPosition)
        {
            MaxPosition = maxPosition;
            MinPosition = minPosition;
        }

        public bool IsInBox(Position? position)
        {
            if (position == null)
            {
                return false;
            }

            if (position.X < MinPosition.X)
            {
                return false;
            }

            if (position.Y < MinPosition.Y)
            {
                return false;
            }


            if (position.X > MaxPosition.X)
            {
                return false;
            }

            if (position.Y > MaxPosition.Y)
            {
                return false;
            }

            return true;
        }
    }
}
