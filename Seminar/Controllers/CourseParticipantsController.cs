using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Seminar.Business.Mappers;
using Seminar.Business.ViewModels;
using Seminar.Data;
using Seminar.Data.Entities;

namespace Seminar.Controllers
{
    public class CourseParticipantsController : Controller
    {
        private readonly CourseParticipantMapper _courseParticipantMapper;

        public CourseParticipantsController()
        {
            _courseParticipantMapper = new CourseParticipantMapper();
        }

        // GET: CourseParticipants/Get/5
        [HttpGet]
        public async Task<ActionResult> Get(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            using (var context = new SeminarDbContext())
            {
                var course = await context.Courses.Include("Participants").SingleAsync(x => x.Id == id);
                if (course == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                return Json(
                    course.Participants.Select(x => _courseParticipantMapper.MapToView(x)).ToList(),
                    JsonRequestBehavior.AllowGet);
            }
        }

        // POST: CourseParticipants/Create
        [HttpPost]
        [ValidateAntiForgeryHeader]
        public async Task<ActionResult> Create(CreateCourseParticipantViewModel courseParticipant) // todo ViewModel CourseId should be GET param.
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var context = new SeminarDbContext())
            {
                var courseModel = await context.Courses.FindAsync(courseParticipant.CourseId);
                if (courseModel == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                context.CourseParticipants.Add(new CourseParticipant
                {
                    Name = courseParticipant.Name,
                    Email = courseParticipant.Email,
                    Course = courseModel
                });

                await context.SaveChangesAsync();
            }

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
    }
}