using System.Collections.Generic;

namespace MovieDatabase.Data.InitialDataLoaders.Models
{
	class MovieJsonModel
	{
		public string Title { get; set; }

		public int Year { get; set; }

		public string Country { get; set; }

		public string Director { get; set; }

		public float Rating { get; set; }

		public string Genre { get; set; }

		public IList<string> Actors { get; set; }
	}
}