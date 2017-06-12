using System.Data.Entity;
using MovieDatabase.Data.ModelConfigurations;
using MovieDatabase.Models;

namespace MovieDatabase.Data
{
	public class MovieDbContext: DbContext
	{
		public MovieDbContext()
			: base("MovieDatabase")
		{
		}

		public DbSet<Movie> Movies { get; set; }

		public DbSet<CastMember> CastMembers { get; set; }

		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new MovieConfiguration());
			modelBuilder.Configurations.Add(new CastMemberConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}