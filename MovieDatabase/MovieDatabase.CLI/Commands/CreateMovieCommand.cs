using System.Collections.Generic;
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
			var movie = new Movie
			{
				Title = paramters[0]
			};

			this.dbContext.Movies.Add(movie);
			this.dbContext.SaveChanges();

			return $"Movie '{movie.Title}' succesfully added!";
		}
	}
}