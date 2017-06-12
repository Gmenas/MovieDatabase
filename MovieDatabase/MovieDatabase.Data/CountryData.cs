using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieDatabase.Data
{
	public static class CountryData
	{
		public static List<Country> countries;

		static CountryData()
		{
			var doc = XDocument.Load("D:\\Documents\\Telerik Academy\\Projects\\MovieDatabase\\MovieDatabase\\MovieDatabase.Data\\countries.xml"); //("..\\..\\..\\MovieDatabase.Data\\countries.xml"); kize bil
			countries = doc.Descendants().Select(x => new Country { Name = x.Value }).Skip(1).ToList();
		}
	}
}
