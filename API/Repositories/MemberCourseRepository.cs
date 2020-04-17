// Code written by Savescu Razvan
using System.Linq;
using API.Context;
using API.Models;
using API.Repositories.Interfaces;

namespace API.Repositories
{
	public class MemberCourseRepository : Repository<MemberCourse>, IMemberCourseRepository
	{
		public MemberCourseRepository(ArtClubContext context) 
			: base(context)
		{
		}

		public int GetOccupiedSlots(int courseId)
		{
			return _dbSet.Count(mc => mc.CourseId == courseId);
		}
	}
}
