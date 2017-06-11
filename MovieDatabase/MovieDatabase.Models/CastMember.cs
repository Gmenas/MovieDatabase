using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.Models
{
	public class CastMember
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Movie> Movies { get; set; }
	}
}