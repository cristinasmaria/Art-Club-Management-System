// Code written by Popescu Cristina
using System;

namespace Common
{
    public class CourseData
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string RoomName { get; set; }
        public int RoomId { get; set; }

        public bool IsMemberEnrolled { get; set; }

        public string TrainerName { get; set; }
        public int TrainerId { get; set; }

        public int TotalNumberOfSeats { get; set; }

        public int NumberOfAvailableSeats { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsApproved { get; set; }
    }
}
