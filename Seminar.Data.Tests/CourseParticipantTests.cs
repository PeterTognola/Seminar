using System.Linq;
using NUnit.Framework;
using Seminar.Data.Entities;
using Seminar.Data.Tests.Helpers;

namespace Seminar.Data.Tests
{
	[TestFixture, Category("Data"), SeminarDatabaseTest]
	public class CourseParticipantTests
	{
		[Test]
		public void CourseTests_AddCourseParticipant_Success()
		{
			// Act
			using (var ctx = new SeminarDbContext())
			{
				ctx.CourseParticipants.Add(new CourseParticipant());
				ctx.SaveChanges();
			}

			// Assert
			using (var ctx = new SeminarDbContext())
			{
				Assert.AreEqual(1, ctx.CourseParticipants.Count());
			}
		}
	}
}