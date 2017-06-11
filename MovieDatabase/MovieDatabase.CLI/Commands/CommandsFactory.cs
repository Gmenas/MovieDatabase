using MovieDatabase.CLI.Common.Console;
using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.CLI.Parsers;
using MovieDatabase.Data;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		private readonly MovieDbContext dbContext;
		private Reader reader;
		private Writer writer;

		public CommandsFactory(MovieDbContext dbContext,Reader reader,Writer writer)
		{
			this.dbContext = dbContext;
			this.reader = reader;
			this.writer = writer;
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
			return new ParseMovie(this.reader, this.writer,this.dbContext).Parse();
		}


	}
}