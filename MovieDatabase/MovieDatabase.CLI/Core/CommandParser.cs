using System.Linq;
using System.Text.RegularExpressions;
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
			var parameters = Regex.Matches(commandText, "(\"[^\"]+\")|\\S+")
				.Cast<Match>()
				.Select(m => m.Value.Replace("\"", ""))
				.ToList();

			var commandName = parameters[0];
			var commandParameters = parameters.Skip(1).ToList();

			var command = this.commandsFactory.CreateCommandFromString(commandName);
			var executionResult = command.Execute(commandParameters);

			return executionResult;
		}
	}
}