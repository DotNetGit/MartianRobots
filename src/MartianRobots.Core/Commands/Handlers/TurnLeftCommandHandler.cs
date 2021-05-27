using MartianRobots.Core.Domain;

namespace MartianRobots.Core.Commands.Handlers
{
    internal class TurnLeftCommandHandler : ICommandHandler
    {
        public void Process(Position position)
        {
            position.Orientation = position.Orientation.Left;
        }
    }
}