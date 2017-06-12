using System.Collections.Generic;

namespace MovieDatabase.Models
{
	public class CastMember
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}