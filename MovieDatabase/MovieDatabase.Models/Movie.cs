using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieDatabase.Models
{
	public class Movie
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int Year { get; set; }

		public virtual Country Country { get; set; }

		public virtual CastMember Director { get; set; }

		public virtual ICollection<CastMember> Actors { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"{this.Title} ({this.Year})");
			sb.AppendLine($"Country: {this.Country.ToString()}");
			sb.AppendLine($"Director: {this.Director}");

			var actors = this.Actors.ToList().Select(x => x.ToString());
			sb.Append($"Cast: {string.Join(", ", actors)}");

			return sb.ToString();
		}
	}
}