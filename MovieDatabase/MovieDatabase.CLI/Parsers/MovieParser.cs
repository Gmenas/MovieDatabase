using System.Linq;
using MovieDatabase.Data;
using MovieDatabase.Data.DbCommands;
using MovieDatabase.Models.Common.Exceptions;

namespace MovieDatabase.CLI.Parsers
{
	class MovieParser : Parser
	{
		private MovieCommand movieCmd;
		private CastMemberCommand castMemberCmd;
		private CountryCommand countryCmd;

		public MovieParser(
			MovieCommand movieCmd,
			CastMemberCommand castMemberCmd, 
			CountryCommand countryCmd)
		{
			this.movieCmd = movieCmd;
			this.castMemberCmd = castMemberCmd;
			this.countryCmd = countryCmd;
		}

		public void Parse()
		{
			var title = GetParameter("Title");
			if (this.movieCmd.Find(title) != null)
			{
				throw new UserException("Movie already exists in the database!");
			}

			var yearStr = GetParameter("Year");
			if (int.TryParse(yearStr, out int year) && yearStr.Length != 4)
			{
				throw new UserException("Invalid year");
			}

			var directorName = GetParameter("Director");
			var director = this.castMemberCmd.FindByName(directorName);
			if (director == null)
			{
				director = this.castMemberCmd.Create(directorName);
			}

			var actors = GetParameter("Actors")
				.Split(',')
				.Select(x => x.Trim())
				.Select(a =>
				{
					var actor = this.castMemberCmd.FindByName(a);
					if (actor == null)
					{
						actor = this.castMemberCmd.Create(a);
					}
					return actor;
				})
				.ToList();

			var countryName = GetParameter("Country");
			var country = this.countryCmd.FindByName(countryName);
			if (country == null)
			{
				throw new UserException("Invalid country");
			}

			var movie = this.movieCmd.Create(title, year, country, director, actors);
		}
	}
}