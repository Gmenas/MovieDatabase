using System;

namespace MovieDatabase.Models.Common.Exceptions
{
	public class UserException: Exception
	{
		public UserException(string message)
			: base($"Error: {message}\n")
		{
		}
	}
}