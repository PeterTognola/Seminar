using Seminar.Business.ViewModels;
using Seminar.Data.Entities;

namespace Seminar.Business.Mappers
{
    public class CourseMapper : IMapper<Course, CourseViewModel>
    {
        public CourseViewModel MapToView(Course model)
        {
            return new CourseViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Instructor = model.Instructor,
                Room = model.Room,
                From = model.From,
                To = model.To
            };
        }

        public Course MapToModel(CourseViewModel view)
        {
            return new Course
            {
                Id = view.Id,
                Name = view.Name,
                Instructor = view.Instructor,
                Room = view.Room,
                From = view.From,
                To = view.To
            };
        }
    }
}