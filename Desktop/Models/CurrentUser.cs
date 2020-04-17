// Code written by Popescu Cristina
using Common;

namespace Desktop.Models
{
	public class CurrentUser
	{
		public UserData UserData { get; set; }

		public bool IsGuest => string.Equals(UserData?.UserRole, UserRoles.Guest);
		public bool IsMember => string.Equals(UserData?.UserRole, UserRoles.Member);
		public bool IsTrainer => string.Equals(UserData?.UserRole, UserRoles.Trainer);
		public bool IsAdmin => string.Equals(UserData?.UserRole, UserRoles.Admin);
	}
}
