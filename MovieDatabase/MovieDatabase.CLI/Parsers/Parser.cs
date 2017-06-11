using System;
using MovieDatabase.Data;

namespace MovieDatabase.CLI.Parsers
{
	public class Parser
	{
		protected MovieDbContext dbContext;

		public Parser(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		protected string GetParameter(string paramName)
		{
			Console.Write($"{paramName}: ");
			string param;

			while (true)
			{
				param = Console.ReadLine();

				if (param == string.Empty)
				{
					Console.WriteLine($"Invalid {paramName}");
				}
				else break;
			}

			return param;
		}
	}
}
