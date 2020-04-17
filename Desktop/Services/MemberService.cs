// Code written by Balana Ovidiu
using Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class MemberService
    {
        private readonly ApiConnector _apiConnector;

        public MemberService(ApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task<IList<CourseData>> GetCoursesAsync(int memberId)
        {
            return await _apiConnector.GetAsync<IList<CourseData>>($"member/getCourses/{memberId}");
        }

        public async Task SaveAsync(IList<CourseData> courses, int memberId)
        {
            await _apiConnector.PostAsync($"member/updateCourses/{memberId}", courses);
        }

		public async Task UpdateMembersAsync(IList<MemberData> members)
		{
			await _apiConnector.PostAsync("member/updateMembers", members);
		}

		public async Task<IList<MemberData>> GetAllMembersAsync()
		{
			return await _apiConnector.GetAsync<IList<MemberData>>("member/getAllMembers");
		}
	}
}
