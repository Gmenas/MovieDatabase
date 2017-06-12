using System;
using System.Linq;
using MovieDatabase.Models;

namespace MovieDatabase.Data.DbCommands
{
	public class CastMemberDbCommand
	{
		private readonly MovieDbContext dbContext;

		public CastMemberDbCommand(MovieDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public CastMember Find(string name)
		{
			var castMember = this.dbContext.CastMembers
				.Where(c => c.Name == name)
				.FirstOrDefault();
			return castMember;
		}

		public CastMember Create(string name)
		{
			if (this.Find(name) != null)
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