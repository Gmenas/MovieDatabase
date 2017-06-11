using System;
using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;
using MovieDatabase.Data;
using MovieDatabase.CLI.Common.Console;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			Console.Title = "MovieDatabase";

			var dbContext = new MovieDbContext();
			var reader = new Reader();
			var writer = new Writer();
			var commandsFactory = new CommandsFactory(dbContext,reader,writer);

			var engine = new Engine(commandsFactory,reader,writer);
			engine.Start();
		}
	}
}