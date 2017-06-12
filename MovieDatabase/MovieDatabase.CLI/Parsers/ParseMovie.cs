using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.CLI.Commands;
using MovieDatabase.Data;

namespace MovieDatabase.CLI.Parsers
{
	class ParseMovie : Parser
	{
		public ParseMovie(MovieDbContext dbContext)
			: base(dbContext)
		{
		}

		public string Parse()
		{
			IList<string> parameters = GetParameters();

			var title = parameters[0];

			if (int.TryParse(parameters[1], out int year) && parameters[1].Length != 4)
			{
				return "Invalid Year";
			}
			Console.WriteLine(year);

			var director = LoadOrCreate.CastMember(dbContext, parameters[2]);

			var actors = parameters[3]
				.Split(',')
				.Select(x => x.Trim())
				.Select(x => LoadOrCreate.CastMember(dbContext, x))
				.ToList();

			var countryName = parameters[4];
			var country = dbContext.Countries.FirstOrDefault(x => x.Name == countryName);

			if (country == null)
			{
				return "Invalid country";
			}

			var movie = LoadOrCreate.Movie(dbContext, title, year, country, director, actors);

			return $"Successfully created {title}\n";
		}

		private IList<string> GetParameters()
		{
			var parameters = new List<string>
			{
				GetParameter("Title"),
				GetParameter("Year"),
				GetParameter("Director"),
				GetParameter("Actors"),
				GetParameter("Country")
			};

			return parameters;
		}
	}
}