using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class MovieDbCommand
	{
		private readonly MovieDbContext dbContext;

		public MovieDbCommand(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Movie Find(string title)
		{
			var movie = this.dbContext.Movies
				.Where(m => m.Title == title)
				.FirstOrDefault();
			return movie;
		}

		public Movie Create(
			string title,
			int year,
			Country country,
			CastMember director,
			float rating,
			Genre genre,
			IList<CastMember> actors)
		{
			if (this.Find(title) != null)
			{
				throw new Exception();
			}

			var movie = new Movie
			{
				Title = title,
				Year = year,
				Country = country,
				Director = director,
				Rating = rating,
				Genre = genre,
				Actors = actors
			};

			this.dbContext.Movies.Add(movie);

			return movie;
		}

		public string List(List<string> parameters)
		{
			IEnumerable<string> movies;
			switch (parameters.FirstOrDefault())
			{
				case "by-title":
					movies = this.dbContext.Movies
						.OrderBy(x => x.Title)
						.ToList()
						.Select(x => x.ToString());
					break;
				case "by-rating":
					movies = this.dbContext.Movies
						.OrderByDescending(x => x.Rating)
						.ToList()
						.Select(x => x.ToString());
					break;
				case "by-most-recent":
					movies = this.dbContext.Movies
						.OrderByDescending(x => x.Year)
						.ToList()
						.Select(x => x.ToString());
					break;
				default: // by-last-aded
					movies = this.dbContext.Movies
						.ToList()
						.Select(x => x.ToString())
						.Reverse();
					break;
			}
			var seperator = new string('-', 20);

			return $"{seperator}\n{string.Join("\n\n", movies)}\n{seperator}";
		}
	}
}