using MovieDatabase.Models;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using MovieDatabase.Data.InitialDataLoaders.Parsers;
using MovieDatabase.Data.DbCommands;
using MovieDatabase.Data.InitialDataLoaders.Models;

namespace MovieDatabase.Data.InitialDataLoaders
{
	public static class InitialData
	{
		public static void AddCountries(MovieDbContext dbContext)
		{
			var document = XDocument.Load("InitialData\\countries.xml");
			var countries = document
				.Descendants()
				.Select(x => new Country { Name = x.Value })
				.Skip(1)
				.ToList();

			dbContext.Countries.AddRange(countries);
		}

		public static void AddMovies(MovieDbContext dbContext)
		{
			var jsonStr = File.ReadAllText("InitialData\\sample-movies.json");
			var movieCmd = new MovieDbCommand(dbContext);
			var movieParser = new CreateMovieParser(
				new MovieDbCommand(dbContext),
				new CastMemberDbCommand(dbContext),
				new CountryDbCommand(dbContext),
				new GenreDbCommand(dbContext)
			);

			var movies = JObject.Parse(jsonStr)["movies"]
				.Children()
				.Select(x => x.ToObject<MovieJsonModel>())
				.ToList();

			movies.ForEach(m =>
			{
				movieParser.ParseFromStr(m.Title, m.Year, m.Country, m.Director, m.Rating, m.Genre, m.Actors);
			});
		}
	}
}