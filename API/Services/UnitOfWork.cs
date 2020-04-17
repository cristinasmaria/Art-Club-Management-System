// Code written by Popescu Cristina
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Repositories.Interfaces;

namespace API.Services
{
	public class UnitOfWork
	{
		private readonly ArtClubContext _context;

		public IRepository<Admin> Admins { get; }
		public IRepository<Course> Courses { get; }
		public IRepository<Event> Events { get; }
		public IRepository<HistoryPart> History { get; }
		public IRepository<Member> Members { get; }
		public IMemberCourseRepository MemberCourses { get; }
		public IRepository<Resource> Inventory { get; }
		public IRepository<Room> Rooms { get; }
		public IRepository<Trainer> Trainers { get; }
		public IRepository<TrainerCourse> TrainerCourses { get; }
		public IRepository<User> Users { get; }

		public UnitOfWork(ArtClubContext context,
			IRepository<Admin> admins,
			IRepository<Course> courses,
			IRepository<Event> events,
			IRepository<HistoryPart> history,
			IRepository<Member> members,
			IMemberCourseRepository memberCourses,
			IRepository<Resource> inventory,
			IRepository<Room> rooms,
			IRepository<Trainer> trainers,
			IRepository<TrainerCourse> trainerCourses,
			IRepository<User> users)
		{
			_context = context;

			Admins = admins;
			Courses = courses;
			Events = events;
			History = history;
			Members = members;
			MemberCourses = memberCourses;
			Inventory = inventory;
			Rooms = rooms;
			Trainers = trainers;
			TrainerCourses = trainerCourses;
			Users = users;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
