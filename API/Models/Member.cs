// Code written by Popescu Cristina
using System.Collections.Generic;

namespace API.Models
{
	public class Member
	{
		public int MemberId { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public decimal MonthlyPayment { get; set; }

		public decimal TotalNeededPayment { get; set; }

		public decimal TotalActualPayment { get; set; }

		public List<MemberCourse> MemberCourses;
	}
}
