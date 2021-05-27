using MartianRobots.Core.Domain;

namespace MartianRobots.Core.Commands.Handlers
{
    internal class MoveForwardCommandHandler : ICommandHandler
    {
        public void Process(Position position)
        {
            switch (position.Orientation.Value)
            {
                case CardinalDirection.N:
                    position.Y++;
                    break;
                case CardinalDirection.S:
                    position.Y--;
                    break;
                case CardinalDirection.E:
                    position.X++;
                    break;
                case CardinalDirection.W:
                    position.X--;
                    break;
            }
        }
    }
}