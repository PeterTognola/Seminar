using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Seminar.Business.Mappers;
using Seminar.Business.ViewModels;
using Seminar.Data;

namespace Seminar.Controllers
{
    public class CourseParticipantsController : Controller
    {
        private readonly CourseMapper _courseMapper;
        private readonly CourseParticipantMapper _courseParticipantMapper;

        public CourseParticipantsController()
        {
            _courseMapper = new CourseMapper();
            _courseParticipantMapper = new CourseParticipantMapper();
        }

        // GET: Courses
        [HttpGet]
        public ActionResult Index()
        {
            using (var context = new SeminarDbContext())
            {
                return Json(context.CourseParticipants.Include("Course").AsEnumerable().Select(x =>
                {
                    var viewModel = _courseParticipantMapper.MapToView(x);
                    viewModel.Course = _courseMapper.MapToView(x.Course);

                    return viewModel;
                }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Courses/Get/5
        [HttpGet]
        public async Task<ActionResult> Get(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Courses/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] CourseParticipantViewModel courseParticipant)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var context = new SeminarDbContext())
            {
                var courseModel = await context.Courses.FindAsync(courseParticipant.Course.Id);
                if (courseModel == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                var model = _courseParticipantMapper.MapToModel(courseParticipant);
                model.Course = courseModel;

                context.CourseParticipants.Add(model);
                await context.SaveChangesAsync();
            }

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        // PUT: Courses/Update/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, CourseViewModel course)
        {
            throw new NotImplementedException();
        }

        // DELETE: Courses/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}