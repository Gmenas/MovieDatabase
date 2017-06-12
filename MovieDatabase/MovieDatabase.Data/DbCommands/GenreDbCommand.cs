﻿using System.Linq;
using MovieDatabase.Models;
using MovieDatabase.Models.Common.Exceptions;

namespace MovieDatabase.Data.DbCommands
{
	public class GenreDbCommand
	{
		private readonly MovieDbContext dbContext;

		public GenreDbCommand(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Genre Find(string name)
		{
			var genre = this.dbContext.Genres
				.Where(g => g.Name == name)
				.FirstOrDefault();
			return genre;
		}

		public Genre Create(string genreName)
		{
			if (this.Find(genreName) != null)
			{
				throw new UserException("Genre already exists!");
			}

			var genre = new Genre
			{
				Name = genreName
			};

			this.dbContext.Genres.Add(genre);

			return genre;
		}
	}
}