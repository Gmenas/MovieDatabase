using MovieDatabase.Models.Common.Exceptions;
using MovieDatabase.CLI.Parsers;
using MovieDatabase.Data;
using MovieDatabase.Data.DbCommands;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		private readonly MovieDbContext dbContext;

		private readonly MovieDbCommand movieCmd;
		private readonly CastMemberDbCommand castMemberCmd;
		private readonly CountryDbCommand countryCmd;

		public CommandsFactory(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;

			this.movieCmd = new MovieDbCommand(this.dbContext);
			this.castMemberCmd = new CastMemberDbCommand(this.dbContext);
			this.countryCmd = new CountryDbCommand(this.dbContext);
		}

		public string RunCommandFromStr(string commandName)
		{
			switch (commandName.ToLower().Trim())
			{
				case "create-movie":
					return this.CreateMovie();
				case "create-actor":
					return this.CreateCastMember();
				case "create-director":
					return this.CreateCastMember();
				case "list-movies":
					return this.ListMovies();
				default:
					throw new UserException($"Command '{commandName}' is not recognised!");
			}
		}

		private string CreateMovie()
		{
			var movieParser = new CreateMovieParser(
				this.movieCmd,
				this.castMemberCmd,
				this.countryCmd
			);

			movieParser.Parse();

			this.dbContext.SaveChanges();

			return "Movie succesfully created!";
		}

		private string CreateCastMember()
		{
			var castMemberParser = new CreateCastMemberParser(
					this.castMemberCmd
			);

			castMemberParser.Parse();

			this.dbContext.SaveChanges();

			return "Actor/director succesfully created!";
		}

		private string ListMovies()
		{
			return this.movieCmd.List();
		}
	}
}