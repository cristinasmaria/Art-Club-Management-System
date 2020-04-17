// Code written by Popescu Cristina
using System;

namespace API.Models
{
	public class Course
	{
		public int CourseId { get; set; }

		public string Name { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public int RoomId { get; set; }
		public Room Room { get; set; }

        public bool IsApproved { get; set; }
	}
}
