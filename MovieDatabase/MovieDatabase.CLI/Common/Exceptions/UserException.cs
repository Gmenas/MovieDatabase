using System;

namespace MovieDatabase.CLI.Common.Exceptions
{
	public class UserException: Exception
	{
		public UserException(string message)
			: base($"Error: {message}")
		{
		}
	}
}