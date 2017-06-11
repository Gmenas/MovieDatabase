using MovieDatabase.CLI.Common.Console;
using MovieDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.CLI.Parsers
{
	public class Parser
	{
		protected Reader reader;
		protected Writer writer;
		protected MovieDbContext dbContext;

		public Parser(Reader reader, Writer writer, MovieDbContext dbContext)
		{
			this.reader = reader;
			this.writer = writer;
			this.dbContext = dbContext;
		}

		protected string GetParameter(string paramName)
		{
			writer.Write($"{paramName}: ");
			string param;

			while (true)
			{
				param = reader.Read();

				if (param == string.Empty)
				{
					writer.WriteLine($"Invalid {paramName}");
				}
				else break;
			}

			return param;
		}
	}
}
