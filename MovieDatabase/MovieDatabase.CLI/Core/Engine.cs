using System;
using MovieDatabase.Models.Common.Exceptions;
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
			Console.Title = "Gmenas - Movie Database";

			while (true)
			{
				string inputLine = Console.ReadLine();

				if (inputLine.ToLower() == "exit")
				{
					break;
				}

				try
				{
					string output = this.factory.RunCommandFromStr(inputLine);
					Console.WriteLine(output);
				}
				catch (UserException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (Exception)
				{
					Console.WriteLine("Unspecified error occured!");
				}
			}
		}
	}
}