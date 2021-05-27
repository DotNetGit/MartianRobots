using System;

using MartianRobots.Core.Commands;

namespace MartianRobots.Core.Domain
{
    public class Robot
    {
        private readonly Grid grid;
        private Position position;
        private readonly ICommandHandlerFactory commandHandlerFactory;

        public Robot(Grid grid, Position position) : this(grid, position, new CommandHandlerFactory())
        {
        }

        public Robot(Grid grid, Position position, ICommandHandlerFactory commandHandlerFactory)
        {
            ValidateGrid(grid);
            ValidatePosition(grid, position);
            ValidateCommandHandlerFactory(commandHandlerFactory);

            this.grid = grid;
            this.position = position;
            this.commandHandlerFactory = commandHandlerFactory;
        }

        public string ExecuteCommands(string commands)
        {
            ValidateCommands(commands);

            foreach (var command in commands)
            {
                var testPosition = new Position(position.X, position.Y, position.Orientation);

                commandHandlerFactory.Create(command).Process(testPosition);

                if (grid.ValidatePosition(testPosition))
                {
                    position = testPosition;
                }
                else if (!grid.CheckPositionScented(position))
                {
                    grid.AddScentedPosition(position);

                    var result = $"{position} LOST";

                    position = testPosition;

                    return result;
                }
            }

            return position.ToString();
        }

        private static void ValidateGrid(Grid grid)
        {
            if (grid == null)
            {
                throw new ArgumentException("Grid cannot be null", nameof(grid));
            }
        }

        private static void ValidatePosition(Grid grid, Position position)
        {
            if (!grid.ValidatePosition(position))
            {
                throw new ArgumentException("Position must be inside grid", nameof(position));
            }
        }

        private static void ValidateCommandHandlerFactory(ICommandHandlerFactory commandHandlerFactory)
        {
            if (commandHandlerFactory == null)
            {
                throw new ArgumentException("CommandHandlerFactory cannot be null", nameof(commandHandlerFactory));
            }
        }

        private static void ValidateCommands(string commands)
        {
            if (commands == null || commands.Length > 100)
            {
                throw new ArgumentException("Commands length must be less than 100 characters", nameof(commands));
            }
        }
    }
}