// Code written by Popescu Cristina
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class CourseService
    {
        private readonly ApiConnector _apiConnector;

        public CourseService(ApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task<bool> SaveNewCourse(CourseData newCourse)
        {
            return await _apiConnector.PostAsync<bool, CourseData>("course/saveNewCourse", newCourse);
        }

        public async Task<List<CourseData>> GetUnapprovedCourses()
        {
            return await _apiConnector.GetAsync<List<CourseData>>("course/getUnapprovedCourses");
        }

        public async Task UpdateCourses(IList<CourseData> courses)
        {
            await _apiConnector.PostAsync<IList<CourseData>>("course/updateCourses", courses);
        }
    }
}
