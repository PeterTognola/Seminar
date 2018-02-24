using System;
using System.Data.Entity;
using NUnit.Framework;

namespace Seminar.Data.Tests.Helpers
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class SeminarDatabaseTestAttribute : Attribute, ITestAction
	{
		public void BeforeTest(TestDetails testDetails)
		{
			Database.SetInitializer(new DropCreateAndMigrateDatabaseInitializer<SeminarDbContext, SeminarDbMigrationsConfiguration>());

			using (var ctx = new SeminarDbContext())
			{
				ctx.Database.Initialize(true);
			}
		}

		public void AfterTest(TestDetails testDetails)
		{
		}

		public ActionTargets Targets
		{
			get { return ActionTargets.Test; }
		}
	}
}