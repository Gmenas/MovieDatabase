using System;
using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.CLI.Commands;

namespace MovieDatabase.CLI.Core
{
	public class Engine
	{
		private readonly CommandsFactory factory;

		public Engine(CommandsFactory factory)
		{
			this.factory = factory;
		}

		public void Start()
		{
			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine.ToLower() == "exit")
				{
					break;
				}

				try
				{
					string output = this.factory.CreateCommandFromString(inputLine);
					Console.WriteLine($" -{output}");
				}
				catch (UserException e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}