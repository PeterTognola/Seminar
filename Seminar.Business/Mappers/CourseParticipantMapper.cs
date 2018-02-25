using Seminar.Business.ViewModels;
using Seminar.Data.Entities;

namespace Seminar.Business.Mappers
{
    public class CourseParticipantMapper : IMapper<CourseParticipant, CourseParticipantViewModel>
    {
        public CourseParticipantViewModel MapToView(CourseParticipant model)
        {
            return new CourseParticipantViewModel
            {
                Id = model.Id,
                Name = model.Name,
                // Course = model.Course, todo.
                Email = model.Email
            };
        }

        public CourseParticipant MapToModel(CourseParticipantViewModel view)
        {
            return new CourseParticipant
            {
                Id = view.Id,
                Name = view.Name,
                // Course = view.Course, todo.
                Email = view.Email
            };
        }
    }
}
