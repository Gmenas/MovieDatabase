using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class MovieCommand
	{
		private MovieDbContext dbContext;

		public MovieCommand(MovieDbContext dbContext)
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

		public Movie Create(string title, int year, Country country, CastMember director, IList<CastMember> actors)
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
				Actors = actors
			};

			this.dbContext.Movies.Add(movie);

			return movie;
		}
	}
}