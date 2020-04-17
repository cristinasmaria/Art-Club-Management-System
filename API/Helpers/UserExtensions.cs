// Code written by Savescu Razvan
using API.Models;
using Common;

namespace API.Helpers
{
	public static class UserExtensions
	{
		public static UserData ToUserData(this User user)
		{
			if (user == null)
			{
				return null;
			}

			var userData = new UserData
			{
				UserId = user.UserId,
				Address = user.Address,
				Age = user.Age,
				Email = user.Email,
				FullName = user.FullName,
				PasswordHash = user.PasswordHash,
				TelephoneNr = user.TelephoneNr,
				Username = user.Username
			};

			return userData;
		}
	}
}
