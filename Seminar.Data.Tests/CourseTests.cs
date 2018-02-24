using System;
using System.Linq;
using NUnit.Framework;
using Seminar.Data.Entities;
using Seminar.Data.Tests.Helpers;

namespace Seminar.Data.Tests
{
	[TestFixture, Category("Data"), SeminarDatabaseTest]
	public class CourseTests
	{
		[Test]
		public void CourseTests_AddCourse_Success()
		{
			// Act
			using (var ctx = new SeminarDbContext())
			{
				ctx.Courses.Add(new Course("Name", "Test", "Test", DateTime.Now, DateTime.Now.AddDays(1)));
				ctx.SaveChanges();
			}

			// Assert
			using (var ctx = new SeminarDbContext())
			{
				Assert.AreEqual(1, ctx.Courses.Count());
				Assert.AreEqual("Name", ctx.Courses.First().Name);
			}
		}
	}
}