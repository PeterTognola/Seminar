using System;
using NUnit.Framework;
using Seminar.Controllers;
using Seminar.Data;
using Microsoft.Data.Entity;

namespace Seminar.App.Tests
{
    [TestFixture, Category("Data")]
    public class CoursesControllerTests
    {
        private SeminarDbContext _context;
        private CoursesController _controller;

        public CoursesControllerTests()
        {
            // Initialize DbContext in memory
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase();
            _context = new MyDbContext(optionsBuilder.Options);

            // Seed data
            _context.People.Add(new Person()
            {
                FirstName = "John",
                LastName = "Doe"
            });
            _context.People.Add(new Person()
            {
                FirstName = "Sally",
                LastName = "Doe"
            });
            _context.SaveChanges();

            // Create test subject
            _controller = new HomeController(_context);
        }

        [Test]
        public void CoursesControllerTests_CourseList()
        {
            
        }
    }
}
