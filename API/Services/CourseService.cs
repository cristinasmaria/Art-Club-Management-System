// Code written by Popescu Cristina
using API.Helpers;
using API.Models;
using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CourseService : AbstractService<Course>
    {

        public CourseService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task SaveNewCourseAsync(CourseData course)
        {
            var newCourse = _unitOfWork.Courses.Add(new Course
            {
                Name = course.Name,
                IsApproved = course.IsApproved,
                StartTime = course.StartTime,
                EndTime = course.EndTime,
                RoomId = course.RoomId
            });

            _unitOfWork.TrainerCourses.Add(new TrainerCourse
            {
                CourseId = newCourse.CourseId,
                TrainerId = course.TrainerId
            });

            await _unitOfWork.SaveChangesAsync();
        }

        public IList<CourseData> GetUnapprovedCourses()
        {
            var unapprovedCourses = _unitOfWork.Courses.All().Include(c => c.Room).Where(c => c.IsApproved == false);

            var result = unapprovedCourses.Select(uc => uc.ToCourseData()).ToList();

            result.ForEach(c =>
            {
                var trainer = _unitOfWork.TrainerCourses.All().Include(tc => tc.Trainer).ThenInclude(t => t.User)
                                         .FirstOrDefault(tc => tc.CourseId == c.CourseId)?.Trainer;
                if (trainer != null)
                {
                    c.TrainerId = trainer.TrainerId;
                    c.TrainerName = trainer.User.FullName;
                }
            });

            return result.ToList();
        }

        public async Task UpdateCoursesAsync(IList<CourseData> courseDatas)
        {
            foreach (var courseData in courseDatas)
            {
                var course = await _unitOfWork.Courses.FindByIdAsync(courseData.CourseId);
                course.UpdateIsApproved(courseData.IsApproved);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
