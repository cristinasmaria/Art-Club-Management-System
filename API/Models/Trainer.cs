// Code written by Streata Alexandra
using System.Collections.Generic;

namespace API.Models
{
	public class Trainer
	{
		public int TrainerId { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public List<TrainerCourse> TrainerCourses { get; set; }
	}
}
