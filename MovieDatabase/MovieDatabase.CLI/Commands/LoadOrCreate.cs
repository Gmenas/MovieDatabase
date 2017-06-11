using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.Data;
using MovieDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.CLI.Commands
{
	static class LoadOrCreate
	{
		public static CastMember CastMember(MovieDbContext dbContext, string name)
		{
			var castMember = dbContext.CastMembers
				.Where(m => m.Name == name)
				.FirstOrDefault();

			if (castMember != null)
			{
				return castMember;
			}

			castMember = new CastMember
			{
				Name = name
			};

			dbContext.CastMembers.Add(castMember);
			dbContext.SaveChanges();
			return castMember;
		}

		public static Movie Movie(MovieDbContext dbContext, string title, int year, CastMember director, ICollection<CastMember> actors)
		{
			var movie = dbContext.Movies
				.Where(m => m.Title == title)
				.FirstOrDefault();

			if (movie != null)
			{
				throw new UserException("Movie already exists");
			}


			movie = new Movie
			{
				Title = title,
				Year = year,
				//Director = director,
				Actors = actors
			};

			dbContext.Movies.Add(movie);
			dbContext.SaveChanges();
			return movie;
		}
	}
}