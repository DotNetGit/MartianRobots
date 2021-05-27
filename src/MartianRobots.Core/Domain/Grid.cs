using System;
using System.Collections.Generic;

namespace MartianRobots.Core.Domain
{
    public class Grid
    {
        private static readonly int MinSize = 0;
        private static readonly int MaxSize = 50;

        private readonly HashSet<Position> scentedPositions;

        public Grid(int width, int height)
        {
            ValidateSize(width, height);

            Width = width;
            Height = height;
            scentedPositions = new HashSet<Position>();
        }

        public int Width { get; }

        public int Height { get; }

        public bool ValidatePosition(Position position)
        {
            return position.X >= MinSize
                && position.X <= Width
                && position.Y >= MinSize
                && position.Y <= Height;
        }

        public void AddScentedPosition(Position position)
        {
            scentedPositions.Add(position);
        }

        public bool CheckPositionScented(Position position)
        {
            return scentedPositions.Contains(position);
        }

        private static void ValidateSize(int width, int height)
        {
            if (width < MinSize || width > MaxSize || height < MinSize || height > MaxSize)
            {
                throw new ArgumentException($"Grid size for any dimension must be in range [{MinSize}, {MaxSize}]");
            }
        }
    }
}