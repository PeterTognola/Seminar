using System;

namespace Seminar.Data.Entities
{
	public class Course
	{
		public int Id { get; private set; }
		public string Name { get; set; }
		public string Instructor { get; set; }
		public string Room { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }

		private Course() { }

		public Course(string name, string instructor, string room, DateTime from, DateTime to)
		{
			Name = name;
			Instructor = instructor;
			Room = room;
			From = @from;
			To = to;
		}
	}
}
