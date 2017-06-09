using System.Collections.Generic;

namespace MovieDatabase.CLI.Commands.Contracts
{
	public interface ICommand
	{
		string Execute(IList<string> paramters);
	}
}