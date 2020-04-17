// Code written by Balana Ovidiu
using API.Models;

namespace API.Repositories.Interfaces
{
	public interface IMemberCourseRepository : IRepository<MemberCourse>
	{
		int GetOccupiedSlots(int courseId);
	}
}
