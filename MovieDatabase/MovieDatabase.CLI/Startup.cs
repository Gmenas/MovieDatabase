using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;
using MovieDatabase.Data;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			var dbContext = new MovieDbContext();
			var commandsFactory = new CommandsFactory(dbContext);
			var engine = new Engine(commandsFactory);
			engine.Start();
		}
	}
}