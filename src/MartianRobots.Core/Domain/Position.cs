namespace MartianRobots.Core.Domain
{
    public record Position
    {
        public Position(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public override string ToString()
        {
            return $"{X}{Y} {Orientation.Value}";
        }
    }
}