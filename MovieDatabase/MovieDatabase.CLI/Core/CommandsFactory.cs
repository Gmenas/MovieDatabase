﻿using MovieDatabase.Models.Common.Exceptions;
using MovieDatabase.CLI.Parsers;
using MovieDatabase.Data;
using MovieDatabase.Data.DbCommands;
using System.Linq;
using System.Collections.Generic;

namespace MovieDatabase.CLI.Commands
{
	public class CommandsFactory
	{
		private readonly MovieDbContext dbContext;

		private readonly MovieDbCommand movieCmd;
		private readonly CastMemberDbCommand castMemberCmd;
		private readonly CountryDbCommand countryCmd;
		private readonly GenreDbCommand genreCmd;

		public CommandsFactory(
			MovieDbContext dbContext,
			MovieDbCommand movieCmd,
			CastMemberDbCommand castMemberCmd,
			CountryDbCommand countryCmd,
			GenreDbCommand genreCmd)
		{
			this.dbContext = dbContext;

			this.movieCmd = movieCmd;
			this.castMemberCmd = castMemberCmd;
			this.countryCmd = countryCmd;
			this.genreCmd = genreCmd;
		}

		public string RunCommandFromStr(string input)
		{
			var commandName = input.ToLower().Split(' ')[0];
			var parameters = input
				.Split(' ')
				.Skip(1)
				.ToList();

			switch (commandName)
			{
				case "create-movie":
					return this.CreateMovie();
				case "create-actor":
					return this.CreateCastMember();
				case "create-director":
					return this.CreateCastMember();
				case "list-movies":
					return this.ListMovies(parameters);
				case "remove-movie":
					return this.RemoveMovie(parameters);
				case "remove-genre":
					return this.RemoveGenre(parameters);
				default:
					throw new UserException($"Command '{commandName}' is not recognised!");
			}
		}

		private string CreateMovie()
		{
			var movieParser = new CreateMovieParser(
				this.movieCmd,
				this.castMemberCmd,
				this.countryCmd,
				this.genreCmd
			);

			movieParser.ParseFromConsole();

			this.dbContext.SaveChanges();

			return "Movie succesfully created!";
		}

		private string RemoveMovie(List<string> parameters)
		{
			var title = string.Join(" ", parameters);

			var genreToCheck = this.movieCmd.Remove(title);
			this.dbContext.SaveChanges();

			if (this.dbContext.Movies.FirstOrDefault(x => x.Genre.Name == genreToCheck) == null)
			{
				RemoveGenre(genreToCheck.Split(' ').ToList());
			}
			this.dbContext.SaveChanges();

			return $"Movie {title} successfully removed!";
		}

		private string RemoveGenre(List<string> parameters)
		{
			var name = string.Join(" ", parameters);

			this.genreCmd.Remove(name);
			this.dbContext.SaveChanges();

			return $"Genre {name} successfully removed!";
		}

		private string CreateCastMember()
		{
			var castMemberParser = new CreateCastMemberParser(
					this.castMemberCmd
			);

			castMemberParser.ParseFromConsole();

			this.dbContext.SaveChanges();

			return "Actor/director succesfully created!";
		}

		private string ListMovies(List<string> parameters)
		{
			return this.movieCmd.List(parameters);
		}
	}
}