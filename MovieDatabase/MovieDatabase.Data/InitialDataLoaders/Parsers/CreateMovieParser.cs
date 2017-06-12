using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.Data.DbCommands;

namespace MovieDatabase.Data.InitialDataLoaders.Parsers
{
	class CreateMovieParser
	{
		private MovieDbCommand movieCmd;
		private CastMemberDbCommand castMemberCmd;
		private CountryDbCommand countryCmd;
		private GenreDbCommand genreCmd;

		public CreateMovieParser(MovieDbCommand movieCmd, CastMemberDbCommand castMemberCmd, CountryDbCommand countryCmd, GenreDbCommand genreCmd)
		{
			this.movieCmd = movieCmd;
			this.castMemberCmd = castMemberCmd;
			this.countryCmd = countryCmd;
			this.genreCmd = genreCmd;
		}

		public void ParseFromStr(
			string title,
			int year,
			string countryName,
			string directorName,
			float rating,
			string genreName,
			IList<string> actorsStr)
		{
			var country = this.countryCmd.Find(countryName);
			if (country == null)
			{
				throw new Exception("Invalid country!");
			}

			var director = this.castMemberCmd.Find(directorName);
			if (director == null)
			{
				director = this.castMemberCmd.Create(directorName);
			}

			var genre = this.genreCmd.Find(genreName);
			if (genre == null)
			{
				genre = this.genreCmd.Create(genreName);
			}

			var actors = actorsStr
				.Select(x => x.Trim())
				.Distinct()
				.Select(aName =>
				{
					var actor = this.castMemberCmd.Find(aName);
					if (actor == null)
					{
						if (aName == director.Name)
						{
							actor = director;
						}
						else
						{
							actor = this.castMemberCmd.Create(aName);
						}
					}
					return actor;
				})
				.ToList();

			this.movieCmd.Create(title, year, country, director, rating, genre, actors);
		}
	}
}