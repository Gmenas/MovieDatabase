using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class CountryDbCommand
	{
		private readonly MovieDbContext dbContext;

		public CountryDbCommand(MovieDbContext dbContext)
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
