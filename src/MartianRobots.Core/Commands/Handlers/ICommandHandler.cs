using MartianRobots.Core.Domain;

namespace MartianRobots.Core.Commands.Handlers
{
    public interface ICommandHandler
    {
        public void Process(Position position);
    }
}