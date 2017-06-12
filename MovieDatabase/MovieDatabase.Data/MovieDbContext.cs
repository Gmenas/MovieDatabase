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

		public DbSet<CastMember> CastMembers { get; set; }

		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Movie>()
			//	.Property(m => m.Title)
			//	.IsRequired()
			//	.HasMaxLength(50)
			//	.HasColumnAnnotation(
			//		IndexAnnotation.AnnotationName,
			//		new IndexAnnotation(
			//			new IndexAttribute() { IsUnique = true }
			//	));

			//modelBuilder.Entity<CastMember>()
			//	.Property(c => c.Name)
			//	.IsRequired()
			//	.HasMaxLength(50)
			//	.HasColumnAnnotation(
			//		IndexAnnotation.AnnotationName,
			//		new IndexAnnotation(
			//			new IndexAttribute() { IsUnique = true }
			//	));

			modelBuilder.Entity<Movie>()
			.HasMany(m => m.Actors)
			.WithMany()
			.Map(x =>
			{
				x.MapLeftKey("Movie_Id");
				x.MapRightKey("Actor_Id");
				x.ToTable("MoviesActors");
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}