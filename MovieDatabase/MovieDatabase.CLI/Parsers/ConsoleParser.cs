using System;

namespace MovieDatabase.CLI.Parsers
{
	public class ConsoleParser
	{
		protected string GetParameter(string paramName)
		{
			string param;

			while (true)
			{
				Console.Write($"  {paramName}: ");
				param = Console.ReadLine();

				if (param == string.Empty)
				{
					Console.WriteLine($"  {paramName} cannot be empty");
				}
				else break;
			}

			return param;
		}
	}
}