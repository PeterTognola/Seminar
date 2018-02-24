using System.Data.Entity.Migrations;

namespace Seminar.Data
{
	public sealed class SeminarDbMigrationsConfiguration : DbMigrationsConfiguration<SeminarDbContext>
	{
		public SeminarDbMigrationsConfiguration()
		{
			AutomaticMigrationsEnabled = true;
		}
	}
}