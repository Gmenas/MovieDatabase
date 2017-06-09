using System;
using MovieDatabase.CLI.Common.Exceptions;

namespace MovieDatabase.CLI.Core
{
	public class Engine
	{
		private CommandParser parser;

		public Engine(CommandParser parser)
		{
			this.parser = parser;
		}

		public void Start()
		{
			while (true)
			{
				string inputLine = Console.ReadLine();

				try
				{
					string output = this.parser.Parse(inputLine);
					Console.WriteLine(output);
				}
				catch (UserException e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}