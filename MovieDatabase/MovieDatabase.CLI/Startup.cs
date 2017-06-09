using System;
using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			Console.Title = "MovieDatabase";

			var commandsFactory = new CommandsFactory();
			var parser = new CommandParser(commandsFactory);

			var engine = new Engine(parser);
			engine.Start();
		}
	}
}