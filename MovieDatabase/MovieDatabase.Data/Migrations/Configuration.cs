using System.Data.Entity.Migrations;
using MovieDatabase.Data.InitialDataLoaders;

namespace MovieDatabase.Data.Migrations
{
	internal sealed class Configuration: DbMigrationsConfiguration<MovieDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(MovieDbContext dbContext)
		{
			dbContext.Countries.AddRange(CountryData.GetCountries());
		}
	}
}