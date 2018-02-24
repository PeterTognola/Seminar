using NUnit.Framework;
using Seminar.Data.Tests.Helpers;

namespace Seminar.Data.Tests
{
	[TestFixture, Category("Data"), SeminarDatabaseTest]
	public class SeminarDbContextTests
	{
		[Test]
		public void SeminarDbContextTests_CreateDatabase_Success()
		{
			// Act
			using (var ctx = new SeminarDbContext())
			{
				// Assert
				Assert.IsTrue(ctx.Database.Exists());
			}
		}
	}
}
