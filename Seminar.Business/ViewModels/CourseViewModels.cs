using System;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Business.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructor { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }
}