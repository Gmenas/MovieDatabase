using System;

namespace MovieDatabase.CLI.Parsers
{
	public class Parser
	{
		protected string GetParameter(string paramName)
		{
			Console.Write($"{paramName}: ");
			string param;

			while (true)
			{
				param = Console.ReadLine();

				if (param == string.Empty)
				{
					Console.WriteLine($"{paramName} cannot be empty");
				}
				else break;
			}

			return param;
		}
	}
}