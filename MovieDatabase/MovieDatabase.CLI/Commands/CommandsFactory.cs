using MovieDatabase.CLI.Commands.Contracts;
using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.Data;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		private readonly MovieDbContext dbContext;

		public CommandsFactory(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public ICommand CreateCommandFromString(string commandName)
		{
			switch (commandName.ToLower())
			{
				case "createmovie":
					return this.CreateMovieCommand();
				default:
					throw new UserException($"Command '{commandName}' is not recognised!");
			}
		}

		private ICommand CreateMovieCommand()
		{
			return new CreateMovieCommand(dbContext);
		}
	}
}