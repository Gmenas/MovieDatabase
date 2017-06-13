using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;
using MovieDatabase.Data;
using MovieDatabase.Data.DbCommands;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			var dbContext = new MovieDbContext();

			var commandsFactory = new CommandsFactory(
				dbContext,
				new MovieDbCommand(dbContext),
				new CastMemberDbCommand(dbContext),
				new CountryDbCommand(dbContext),
				new GenreDbCommand(dbContext)
			);

			var engine = new Engine(commandsFactory);
			engine.Start();
		}
	}
}