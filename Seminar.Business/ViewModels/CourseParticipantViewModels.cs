using System.ComponentModel.DataAnnotations;

namespace Seminar.Business.ViewModels
{
    public class CourseParticipantViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public CourseViewModel Course { get; set; }
    }
}