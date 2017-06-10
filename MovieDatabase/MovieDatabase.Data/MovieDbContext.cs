using System.Data.Entity;
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
	}
}