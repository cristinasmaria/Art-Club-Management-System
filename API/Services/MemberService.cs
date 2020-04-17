// Code written by Balana Ovidiu
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
	public class MemberService : AbstractService<Member>
	{
		public MemberService(UnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public IList<CourseData> GetAllCourses(int memberId)
		{
			var coursesPerMember = GetCoursesPerMember(memberId);

			var allCourses = _unitOfWork.Courses.All().Where(c => !coursesPerMember.Select(cpm => cpm.CourseId).Contains(c.CourseId));
			var coursesTheMemberHasNotEnrolledInto = _unitOfWork.Courses.All().Include(c => c.Room).Join(allCourses, c => c.CourseId, mc => mc.CourseId, (c, mc) => new CourseData
			{
				CourseId = c.CourseId,
				Name = c.Name,
				StartTime = c.StartTime,
				EndTime = c.EndTime,
				RoomName = c.Room.Name,
				IsMemberEnrolled = false,
				TotalNumberOfSeats = c.Room.NrSeats,
                IsApproved = c.IsApproved
            }).ToList();

			coursesTheMemberHasNotEnrolledInto.ForEach(c =>
			{
				var numberOccupiedSlots = _unitOfWork.MemberCourses.GetOccupiedSlots(c.CourseId);

				c.NumberOfAvailableSeats = c.TotalNumberOfSeats - numberOccupiedSlots;
				c.IsEnabled = c.NumberOfAvailableSeats != 0;
			});

			foreach (var c in coursesTheMemberHasNotEnrolledInto)
			{
				var trainer = _unitOfWork.TrainerCourses.All().FirstOrDefault(t => t.CourseId == c.CourseId)?.Trainer?.User;
				if (trainer != null)
				{
					c.TrainerName = _unitOfWork.Users.All().FirstOrDefault(u => u.UserId == trainer.UserId)?.FullName;
				}
			}

			coursesPerMember = coursesPerMember.Concat(coursesTheMemberHasNotEnrolledInto).ToList();

			return coursesPerMember.GroupBy(c => c.CourseId).Select(c => c.FirstOrDefault()).OrderByDescending(c => c.IsMemberEnrolled).ToList();
		}

		public async Task UpdateMembers(IList<MemberData> memberDatas)
		{
			foreach (var memberData in memberDatas)
			{
				var member = await _unitOfWork.Members.FindByIdAsync(memberData.MemberId);
				member.UpdateData(memberData);
			}

			await _unitOfWork.SaveChangesAsync();
		}

		public IList<MemberData> GetAllMembers()
		{
			return _unitOfWork.Members.All().Include(m => m.User).Select(m => m.ToMemberData()).ToList();
		}

		public async Task UpdateCoursesAsync(IList<CourseData> coursesData, int memberId)
		{
			var courseIds = _unitOfWork.MemberCourses.All().Where(mc => mc.MemberId == memberId).Select(mc => mc.CourseId);

			var coursesToAdd = coursesData.Where(c => !courseIds.Contains(c.CourseId) && c.IsMemberEnrolled).ToList();

			foreach (var course in coursesToAdd)
			{
				_unitOfWork.MemberCourses.Add(new MemberCourse
				{
					CourseId = course.CourseId,
					MemberId = memberId
				});
			}

			var coursesToRemove = coursesData.Except(coursesToAdd).Where(c => courseIds.Contains(c.CourseId) && !c.IsMemberEnrolled).ToList();

			foreach (var course in coursesToRemove)
			{
				var memberCourse = _unitOfWork.MemberCourses.All().FirstOrDefault(mc => mc.CourseId == course.CourseId && mc.MemberId == memberId);
				_unitOfWork.MemberCourses.Delete(memberCourse);
			}

			await _unitOfWork.SaveChangesAsync();
		}

		private IList<CourseData> GetCoursesPerMember(int memberId)
		{
			var memberCourses = _unitOfWork.MemberCourses.All().Where(mc => mc.MemberId == memberId);

			var coursesPerMember = _unitOfWork.Courses.All().Include(c => c.Room).Join(memberCourses, c => c.CourseId, mc => mc.CourseId, (c, mc) => new CourseData
			{
				CourseId = c.CourseId,
				Name = c.Name,
				StartTime = c.StartTime,
				EndTime = c.EndTime,
				RoomName = c.Room.Name,
				IsMemberEnrolled = true,
				TotalNumberOfSeats = c.Room.NrSeats,
                IsApproved = c.IsApproved
			}).ToList();

			coursesPerMember.ForEach(c =>
			{
				var numberOccupiedSlots = _unitOfWork.MemberCourses.GetOccupiedSlots(c.CourseId);

				c.NumberOfAvailableSeats = c.TotalNumberOfSeats - numberOccupiedSlots;
				c.IsEnabled = c.NumberOfAvailableSeats != 0;
			});

			foreach (var c in coursesPerMember)
            {
                var trainer = _unitOfWork.TrainerCourses.All().Include(tc => tc.Trainer).ThenInclude(t => t.User)
                                         .FirstOrDefault(t => t.CourseId == c.CourseId)?.Trainer;
                if (trainer != null)
				{
					c.TrainerName = trainer.User.FullName;
				}
			}

			return coursesPerMember.ToList();
		}

		public override async Task AddAsync(Member entity)
		{
			_unitOfWork.Members.Add(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public override IQueryable<Member> All()
		{
			return _unitOfWork.Members.All();
		}

		public override async Task DeleteAsync(Member entity)
		{
			_unitOfWork.Members.Delete(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public override async Task<Member> FindByIdAsync(int? id)
		{
			if (id.HasValue)
			{
				return await _unitOfWork.Members.FindByIdAsync(id.Value);
			}
			else
			{
				return null;
			}
		}

		public override async Task UpdateAsync(Member entity)
		{
			_unitOfWork.Members.Update(entity);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
