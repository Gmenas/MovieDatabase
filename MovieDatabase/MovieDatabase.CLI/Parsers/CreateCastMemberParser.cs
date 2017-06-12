using MovieDatabase.Data.DbCommands;
using MovieDatabase.Models.Common.Exceptions;

namespace MovieDatabase.CLI.Parsers
{
	class CreateCastMemberParser: Parser
	{
		private CastMemberDbCommand castMemberCmd;

		public CreateCastMemberParser(CastMemberDbCommand castMemberCmd)
		{
			this.castMemberCmd = castMemberCmd;
		}

		public void ParseFromConsole()
		{
			var name = GetParameter("Name");
			if (this.castMemberCmd.Find(name) != null)
			{
				throw new UserException("Actor/director already exists!");
			}

			var movie = this.castMemberCmd.Create(name);
		}
	}
}