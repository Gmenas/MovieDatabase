using System;
using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class CastMemberCommand
	{
		private MovieDbContext dbContext;

		public CastMemberCommand(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public CastMember FindByName(string name)
		{
			var castMember = this.dbContext.CastMembers
				.Where(c => c.Name == name)
				.FirstOrDefault();
			return castMember;
		}

		public CastMember Create(string name)
		{
			if (this.FindByName(name) != null)
			{
				throw new Exception();
			}

			var castMember = new CastMember
			{
				Name = name
			};

			this.dbContext.CastMembers.Add(castMember);

			return castMember;
		}
	}
}