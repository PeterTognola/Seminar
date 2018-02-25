namespace Seminar.Data.Entities
{
	public class CourseParticipant
	{
		public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual Course Course { get; set; }
	}
}