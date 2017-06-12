using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class CountryCommand
	{
		private MovieDbContext dbContext;

		public CountryCommand(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Country FindByName(string name)
		{
			var country = this.dbContext.Countries
				.Where(c => c.Name == name)
				.FirstOrDefault();
			return country;
		}
	}
}
