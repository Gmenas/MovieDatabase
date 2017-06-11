using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>()
				.Property(m => m.Title)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(
						new IndexAttribute() { IsUnique = true }
				));

			base.OnModelCreating(modelBuilder);
		}
	}
}