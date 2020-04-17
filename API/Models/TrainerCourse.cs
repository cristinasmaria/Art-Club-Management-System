// Code written by Streata Alexandra
namespace API.Models
{
	public class TrainerCourse
	{
		public int TrainerCourseId { get; set; }

		public int TrainerId { get; set; }
		public Trainer Trainer { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
