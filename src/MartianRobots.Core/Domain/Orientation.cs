using System;

namespace MartianRobots.Core.Domain
{
    public class Orientation
    {
        public static readonly Orientation N = new(CardinalDirection.N, () => W, () => E);
        public static readonly Orientation S = new(CardinalDirection.S, () => E, () => W);
        public static readonly Orientation E = new(CardinalDirection.E, () => N, () => S);
        public static readonly Orientation W = new(CardinalDirection.W, () => S, () => N);

        private readonly Lazy<Orientation> left;
        private readonly Lazy<Orientation> right;

        private Orientation(CardinalDirection value, Func<Orientation> left, Func<Orientation> right)
        {
            Value = value;
            this.left = new Lazy<Orientation>(left);
            this.right = new Lazy<Orientation>(right);
        }

        public CardinalDirection Value { get; }

        public Orientation Left
        {
            get => left.Value;
        }

        public Orientation Right
        {
            get => right.Value;
        }
    }
}