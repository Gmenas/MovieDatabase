using System;
using MovieDatabase.CLI.Commands;
using MovieDatabase.CLI.Core;
using MovieDatabase.Data;
using MovieDatabase.Models;
using System.Xml.Linq;
using System.Linq;

namespace MovieDatabase.CLI
{
	class Startup
	{
		public static void Main()
		{
			Console.Title = "MovieDatabase";
			var dbContext = new MovieDbContext();
			var commandsFactory = new CommandsFactory(dbContext);

			var engine = new Engine(commandsFactory);
			engine.Start();
		}
	}
}