using System;
using System.Collections.Generic;
using System.Linq;
using MovieDatabase.CLI.Commands.Contracts;
using MovieDatabase.CLI.Common.Exceptions;
using MovieDatabase.Data;

namespace MovieDatabase.CLI.Commands
{
	public abstract class Command: ICommand
	{
		protected readonly MovieDbContext dbContext;
		protected readonly uint ParameterCount;

		public Command(MovieDbContext dbContext, uint parameterCount)
		{
			this.dbContext = dbContext ?? throw new ArgumentNullException();
			this.ParameterCount = parameterCount;
		}

		public abstract string Execute(IList<string> parameters);

		protected void ValidateParameters(IList<string> parameters)
		{
			if (parameters.Count != this.ParameterCount)
			{
				throw new UserException("Invalid command parameters count!");
			}

			if (parameters.Any(x => x == string.Empty))
			{
				throw new UserException("Some of the passed parameters are empty!");
			}
		}
	}
}