// Code written by Savescu Razvan
namespace Common
{
	public class UserData : LoginData
	{
		public int UserId { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public int? Age { get; set; }

		public string Address { get; set; }

		public string TelephoneNr { get; set; }

		public string UserRole { get; set; }

		public string NewUserRole { get; set; }

		public int MemberId { get; set; }

		public int TrainerId { get; set; }

		public int AdminId { get; set; }
	}
}
