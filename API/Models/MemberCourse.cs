// Code written by Popescu Cristina
namespace API.Models
{
	public class MemberCourse
	{
		public int MemberCourseId { get; set; }

		public int MemberId { get; set; }
		public Member Member { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
