using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.CLI.Parsers;
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

		public string CreateCommandFromString(string commandName)
		{
			switch (commandName.ToLower())
			{
				case "createmovie":
					return this.ParseMovie();
				default:
					throw new UserException($"Command '{commandName}' is not recognised!");
			}
		}

		private string ParseMovie()
		{
			return new ParseMovie(this.dbContext).Parse();
		}
	}
}