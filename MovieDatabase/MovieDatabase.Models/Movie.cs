using System.Collections.Generic;

namespace MovieDatabase.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int Year { get; set; }

		//public CastMember Director { get; set; }

		public virtual ICollection<CastMember> Actors { get; set; }
	}
}