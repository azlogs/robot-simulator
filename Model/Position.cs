namespace Model
{
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
        public Position(Position? position)
        {
            if (position == null) return;
            X = position.X;
            Y = position.Y;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    };
}