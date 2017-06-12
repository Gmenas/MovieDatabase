using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using MovieDatabase.Models;

namespace MovieDatabase.Data.ModelConfigurations
{
	public class CastMemberConfiguration: EntityTypeConfiguration<CastMember>
	{
		public CastMemberConfiguration()
		{
			this
				.Property(m => m.Name)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(
						new IndexAttribute() { IsUnique = true }
				));
		}
	}
}