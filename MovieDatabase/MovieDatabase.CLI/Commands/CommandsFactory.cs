using System;
using MovieDatabase.CLI.Commands.Contracts;
using MovieDatabase.CLI.Common.Exceptions;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		public CommandsFactory()
		{
		}

		public ICommand CreateCommandFromString(string commandName)
		{
			switch (commandName.ToLower())
			{
				case "createmovie":
					return this.CreateMovieCommand();
				default:
					throw new UserException($"Command '{commandName}' is not recognised!");
			}
		}

		public ICommand CreateMovieCommand()
		{
			throw new NotImplementedException();
		}
	}
}