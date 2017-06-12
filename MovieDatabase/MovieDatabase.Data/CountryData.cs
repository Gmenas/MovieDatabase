using MovieDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MovieDatabase.Data
{
	public static class CountryData
	{
		public static List<Country> GetCountries()
		{
			var document = XDocument.Load("InitialData\\countries.xml");
			var countries = document
				.Descendants()
				.Select(x => new Country { Name = x.Value })
				.Skip(1)
				.ToList();
			return countries;
		}
	}
}