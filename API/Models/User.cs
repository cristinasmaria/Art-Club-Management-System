// Code written by Savescu Razvan
namespace API.Models
{
	public class User
	{
		public int UserId { get; set; }

		public string Username { get; set; }

		public string PasswordHash { get; set; }

		public string Email { get; set; }

		public string FullName { get; set; }

		public int Age { get; set; }

		public string Address { get; set; }

		public string TelephoneNr { get; set; }
	}
}
