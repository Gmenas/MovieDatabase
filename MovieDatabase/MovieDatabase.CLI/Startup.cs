using System;
using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;
using MovieDatabase.Data;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			Console.Title = "MovieDatabase";

			var dbContext = new MovieDbContext();
			var commandsFactory = new CommandsFactory(dbContext);
			var parser = new CommandParser(commandsFactory);

			var engine = new Engine(parser);
			engine.Start();
		}
	}
}