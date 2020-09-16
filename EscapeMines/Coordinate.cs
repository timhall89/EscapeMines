namespace EscapeMines
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override int GetHashCode() => $"{X}-{Y}".GetHashCode();
        public override bool Equals(object obj)
            => obj is Coordinate coordinate && coordinate.GetHashCode() == GetHashCode();
    }
}
