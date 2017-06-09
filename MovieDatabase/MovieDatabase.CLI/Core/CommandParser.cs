using System.Linq;
using MovieDatabase.CLI.Commands;

namespace MovieDatabase.CLI.Core
{
	public class CommandParser
	{
		private CommandsFactory commandsFactory;

		public CommandParser(CommandsFactory commandsFactory)
		{
			this.commandsFactory = commandsFactory;
		}

		public string Parse(string commandText)
		{
			var commandName = commandText.Split(' ')[0];
			var commandParameters = commandText
				.Split(' ')
				.Skip(1)
				.ToList();

			var command = this.commandsFactory.CreateCommandFromString(commandName);
			var executionResult = command.Execute(commandParameters);

			return executionResult;
		}
	}
}