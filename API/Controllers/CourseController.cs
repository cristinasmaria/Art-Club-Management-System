// Code written by Popescu Cristina
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("saveNewCourse")]
        public async Task<ActionResult<bool>> SaveNewCourse([FromBody]CourseData course)
        {
            if (course == null)
            {
                return BadRequest(false);
            }

            await _courseService.SaveNewCourseAsync(course);
            return Ok(true);
        }

        [HttpGet("getUnapprovedCourses")]
        public IList<CourseData> GetUnapprovedCourses()
        {
            return _courseService.GetUnapprovedCourses();
        }
        
        [HttpPost("updateCourses")]
        public async Task UpdateCourses([FromBody]IList<CourseData> courseDatas)
        {
            await _courseService.UpdateCoursesAsync(courseDatas);
        }
    }
}
