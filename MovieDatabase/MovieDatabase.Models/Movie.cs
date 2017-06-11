using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int Year { get; set; }

		public virtual CastMember Director { get; set; }

		public virtual ICollection<CastMember> Actors { get; set; }
	}
}