using MartianRobots.Core.Commands.Handlers;

namespace MartianRobots.Core.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler Create(char command);
    }
}