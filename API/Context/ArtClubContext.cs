// Code written by Popescu Cristina
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
	public class ArtClubContext : DbContext
	{
		public ArtClubContext(DbContextOptions<ArtClubContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<MemberCourse> MemberCourses { get; set; }
		public DbSet<TrainerCourse> TrainerCourses { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Resource> Inventory { get; set; }
		public DbSet<HistoryPart> History { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
	}
}
