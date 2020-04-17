// Code written by Popescu Cristina
using API.Models;
using Common;

namespace API.Helpers
{
    public static class CourseExtensions
    {
        public static CourseData ToCourseData(this Course course)
        {
            return new CourseData
            {
                Name = course.Name,
                CourseId = course.CourseId,
                IsApproved = course.IsApproved,
                RoomId = course.RoomId,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                RoomName = course.Room.Name,
                TotalNumberOfSeats = course.Room.NrSeats
            };
        }

        public static void UpdateIsApproved(this Course course, bool isApproved)
        {
            course.IsApproved = isApproved;
        }
    }
}
