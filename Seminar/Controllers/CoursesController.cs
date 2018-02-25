using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Seminar.Business.Mappers;
using Seminar.Business.ViewModels;
using Seminar.Data;

namespace Seminar.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseMapper _courseMapper;

        public CoursesController()
        {
            _courseMapper = new CourseMapper();
        }

        // GET: Courses
        [HttpGet]
        public ActionResult Index()
        {
            using (var context = new SeminarDbContext())
            {
                return Json(context.Courses.AsEnumerable().Select(x => _courseMapper.MapToView(x)).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Courses/Get/5
        [HttpGet]
        public async Task<ActionResult> Get(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var context = new SeminarDbContext())
            {
                var course = await context.Courses.FindAsync(id);
                if (course == null) return HttpNotFound();

                return Json(_courseMapper.MapToView(course), JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryHeader]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] CourseViewModel course)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var context = new SeminarDbContext())
            {
                var model = _courseMapper.MapToModel(course);
                context.Courses.Add(model);
                await context.SaveChangesAsync();
            }

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
    }
}