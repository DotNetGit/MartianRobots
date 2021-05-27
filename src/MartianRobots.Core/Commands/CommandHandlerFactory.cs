using System;
using System.Collections.Generic;

using MartianRobots.Core.Commands.Handlers;
using MartianRobots.Core.Domain;

namespace MartianRobots.Core.Commands
{
    internal class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly ICommandHandler nullHandler = new NullCommandHandler();
        private readonly Dictionary<char, Func<ICommandHandler>> mapping;

        public CommandHandlerFactory()
        {
            mapping = new Dictionary<char, Func<ICommandHandler>>
                          {
                              ['L'] = () => new TurnLeftCommandHandler(),
                              ['R'] = () => new TurnRightCommandHandler(),
                              ['F'] = () => new MoveForwardCommandHandler()
                          };
        }

        public ICommandHandler Create(char command)
        {
            return mapping.TryGetValue(command, out var handlerFunc) ? handlerFunc() : nullHandler;
        }

        private class NullCommandHandler : ICommandHandler
        {
            public void Process(Position position)
            {
            }
        }
    }
}