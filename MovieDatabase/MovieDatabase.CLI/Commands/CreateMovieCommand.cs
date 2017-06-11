using System.Collections.Generic;
using System.Linq;
using MovieDatabase.CLI.Commands.Contracts;
using MovieDatabase.Data;
using MovieDatabase.Models;

namespace MovieDatabase.CLI.Commands
{
	public class CreateMovieCommand: Command, ICommand
	{
		public CreateMovieCommand(MovieDbContext dbContext)
			: base(dbContext, 1)
		{
		}

		public override string Execute(IList<string> paramters)
		{
			this.ValidateParameters(paramters);

			string title = paramters[0];

			bool movieExists = dbContext.Movies
				.Where(m => m.Title == title)
				.FirstOrDefault() != null;
			if (movieExists)
			{
				return $"Movie '{title}' already exists!";
			}

			var movie = new Movie
			{
				Title = title
			};
			this.dbContext.Movies.Add(movie);

			this.dbContext.SaveChanges();

			return $"Movie '{title}' succesfully added!";
		}
	}
}