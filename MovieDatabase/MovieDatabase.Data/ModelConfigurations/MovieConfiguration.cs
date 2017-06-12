using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using MovieDatabase.Models;

namespace MovieDatabase.Data.ModelConfigurations
{
	public class MovieConfiguration: EntityTypeConfiguration<Movie>
	{
		public MovieConfiguration()
		{
			this
				.Property(m => m.Title)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(
						new IndexAttribute() { IsUnique = true }
				));

			this
				.HasMany(m => m.Actors)
				.WithMany()
				.Map(x =>
				{
					x.MapLeftKey("Movie_Id");
					x.MapRightKey("Actor_Id");
					x.ToTable("MoviesActors");
				});
		}
	}
}