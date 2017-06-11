using System;
using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.CLI.Common.Console;
using MovieDatabase.CLI.Commands;

namespace MovieDatabase.CLI.Core
{
	public class Engine
	{
		private readonly CommandsFactory factory;
		private Reader reader;
		private Writer writer;

		public Engine(CommandsFactory factory,Reader reader,Writer writer)
		{
			this.factory = factory;
			this.reader = reader;
			this.writer = writer;
		}

		public void Start()
		{
			while (true)
			{
				string inputLine = this.reader.Read();

				if (inputLine.ToLower() == "exit")
				{
					break;
				}

				try
				{
					string output = this.factory.CreateCommandFromString(inputLine);
					this.writer.WriteLine($" -{output}");
				}
				catch (UserException e)
				{
					this.writer.WriteLine(e.Message);
				}
			}
		}
	}
}