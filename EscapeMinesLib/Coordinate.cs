namespace EscapeMinesLib
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode() => $"{X}-{Y}".GetHashCode();
        public override bool Equals(object obj)
            => obj is Coordinate coordinate && coordinate.GetHashCode() == GetHashCode();
    }
}
