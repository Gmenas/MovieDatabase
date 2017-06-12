using System.Linq;
using MovieDatabase.Data.DbCommands;
using MovieDatabase.Models.Common.Exceptions;

namespace MovieDatabase.CLI.Parsers
{
	class CreateMovieParser: Parser
	{
		private readonly MovieDbCommand movieCmd;
		private readonly CastMemberDbCommand castMemberCmd;
		private readonly CountryDbCommand countryCmd;
		private readonly GenreDbCommand genreCmd;

		public CreateMovieParser(
			MovieDbCommand movieCmd,
			CastMemberDbCommand castMemberCmd, 
			CountryDbCommand countryCmd,
			GenreDbCommand genreCmd)
		{
			this.movieCmd = movieCmd;
			this.castMemberCmd = castMemberCmd;
			this.countryCmd = countryCmd;
			this.genreCmd = genreCmd;
		}

		public void Parse()
		{
			var title = GetParameter("Title");
			if (this.movieCmd.Find(title) != null)
			{
				throw new UserException("Movie already exists in the database!");
			}

			var yearStr = GetParameter("Year");
			if (!int.TryParse(yearStr, out int year) ||
				yearStr.Length != 4)
			{
				throw new UserException("Invalid year!");
			}

			var countryName = GetParameter("Country");
			var country = this.countryCmd.Find(countryName);
			if (country == null)
			{
				throw new UserException("Invalid country!");
			}

			var directorName = GetParameter("Director");
			var director = this.castMemberCmd.Find(directorName);
			if (director == null)
			{
				director = this.castMemberCmd.Create(directorName);
			}

			var ratingStr = GetParameter("Rating (0-10)");
			if (!float.TryParse(ratingStr, out float rating))
			{
				throw new UserException("Invalid rating!");
			}
			if (rating < 0.0f || rating > 10.0f)
			{
				throw new UserException("Rating must be between 0 and 10");
			}

			var genreName = GetParameter("Genre");
			var genre = this.genreCmd.Find(genreName);
			if (genre == null)
			{
				genre = this.genreCmd.Create(genreName);
			}

			var actors = GetParameter("Cast (seperate with commas)")
				.Split(',')
				.Select(x => x.Trim())
				.Distinct()
				.Select(aName =>
				{
					var actor = this.castMemberCmd.Find(aName);
					if (actor == null && aName != director.Name)
					{
						actor = this.castMemberCmd.Create(aName);
					}
					return actor;
				})
				.ToList();

			var movie = this.movieCmd.Create(title, year, country, director, rating, genre, actors);
		}
	}
}