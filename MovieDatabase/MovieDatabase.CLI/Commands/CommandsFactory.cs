using MovieDatabase.Models.Common.Exceptions;
using MovieDatabase.CLI.Parsers;
using MovieDatabase.Data;
using MovieDatabase.Data.DbCommands;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		private readonly MovieDbContext dbContext;

		private readonly MovieCommand movieCmd;
		private readonly CastMemberCommand castMemberCmd;
		private readonly CountryCommand countryCmd;

		public CommandsFactory(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;

			this.movieCmd = new MovieCommand(this.dbContext);
			this.castMemberCmd = new CastMemberCommand(this.dbContext);
			this.countryCmd = new CountryCommand(this.dbContext);
		}

		public string RunCommandFromStr(string commandName)
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
			var movieParser = new MovieParser(
				this.movieCmd,
				this.castMemberCmd,
				this.countryCmd);

			movieParser.Parse();

			dbContext.SaveChanges();

			return "Movie succesfully created!";
		}
	}
}