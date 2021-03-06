﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Globalization;
using Seminar.Data.Entities;

namespace Seminar.Data
{
	public class SeminarDbContext : DbContext
	{
		public DbSet<Course> Courses { get; set; }

		public DbSet<CourseParticipant> CourseParticipants { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			if (modelBuilder == null) throw new ArgumentNullException("modelBuilder");

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			// Load mappings from assembly
			modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
		}

		public SeminarDbContext() : base("Seminar")
		{
		}

		public override int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				var message = "";
				foreach (var eve in e.EntityValidationErrors)
				{
					var line = string.Format(CultureInfo.CurrentCulture,
						"Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					message += line + "\r\n";
					Console.WriteLine(line);

					foreach (var ve in eve.ValidationErrors)
					{
						line = string.Format(CultureInfo.CurrentCulture, "- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
						message += line + "\r\n";
						Console.WriteLine(line);
					}
				}
				throw new DbEntityValidationException(message, e);
			}
		}

	}
}
