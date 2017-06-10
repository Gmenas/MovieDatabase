using System.Data.Entity.Migrations;

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

		}
	}
}