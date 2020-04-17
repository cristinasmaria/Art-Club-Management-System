// Code written by Balana Ovidiu
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("getCourses/{memberId}")]
        public IList<CourseData> GetCourses(int memberId)
        {
            return _memberService.GetAllCourses(memberId);
        }

		[HttpGet("getAllMembers")]
		public IList<MemberData> GetAllMembers()
		{
			return _memberService.GetAllMembers();
		}

		[HttpPost("updateMembers")]
		public async Task UpdateMembers([FromBody]IList<MemberData> memberDatas)
		{
			await _memberService.UpdateMembers(memberDatas);
		}

		[HttpPost("updateCourses/{memberId}")]
        public async Task UpdateCourses([FromBody]IList<CourseData> coursesData, int memberId)
        {
            await _memberService.UpdateCoursesAsync(coursesData, memberId);
        }
    }
}
